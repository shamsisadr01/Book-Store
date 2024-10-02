using Common.AspNetCore;
using Common.L1.Domain.ValueObjects;
using Common.L2.Application;
using Common.L2.Application.SecurityUtil;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.JwtUtil;
using Shop.Api.ViewModels.Auth;
using Shop.L1.Domain.User_Aggregate;
using Shop.L2.Application.Users.AddToken;
using Shop.L2.Application.Users.Create;
using Shop.L2.Application.Users.Register;
using Shop.L2.Application.Users.RemoveToken;
using Shop.L4.Query.Users.DTOs;
using Shop.L5.Presentation.Facade.Users;
using UAParser;

namespace Shop.Api.Controllers
{
	
	public class AuthController : ApiController
	{
		private readonly IUserFacade _userFacade;
		private readonly IConfiguration _configuration;

		public AuthController(IUserFacade userFacade, IConfiguration configuration)
		{
			_userFacade = userFacade;
			_configuration = configuration;
		}

		[HttpPost("login")]
		public async Task<ApiResult<LoginResultDto?>> Login(LoginViewModel loginViewModel)
		{
			if (ModelState.IsValid == false)
			{
				return new ApiResult<LoginResultDto?>()
				{
					IsSuccess = false,
					Data = null,
					MetaData = new()
					{
						AppStatusCode = AppStatusCode.BadRequest,
						Message = JoinErrors()
					}
				};
			}
			var user = await _userFacade.GetUserByPhoneNumber(loginViewModel.PhoneNumber);
			if (user == null)
			{
				var result = OperationResult<LoginResultDto>.Error("کاربری با مشخصات وارد شده یافت نشد.");
				return CommandResult(result);
			}
			if (Sha256Hasher.IsCompare(user.Password, loginViewModel.Password) == false)
			{
				var result = OperationResult<LoginResultDto>.Error("کاربری با مشخصات وارد شده یافت نشد.");
				return CommandResult(result);
			}
			if (user.IsActive == false)
			{
				var result = OperationResult<LoginResultDto>.Error("حساب کاربری شما غیر فعال است.");
				return CommandResult(result);
			}

			var loginResult = await AddTokenAndGenerateJwt(user);
			return CommandResult(loginResult);
		
		}

		[HttpPost("register")]
		public async Task<ApiResult> Register(RegisterViewModel registerViewModel)
		{
			if (ModelState.IsValid == false)
			{
				return new ApiResult()
				{
					IsSuccess = false,
					MetaData = new()
					{
						AppStatusCode = AppStatusCode.BadRequest,
						Message = JoinErrors()
					}
				};
			}
			var command = new RegisterUserCommand(new PhoneNumber(registerViewModel.PhoneNumber),
				registerViewModel.Password);
			var result = await _userFacade.RegisterUser(command);

			return CommandResult(result);
		}

		[HttpPost("RefreshToken")]
		public async Task<ApiResult<LoginResultDto?>> RefreshToken(string refreshToken)
		{
			var result = await _userFacade.GetUserTokenByRefreshToken(refreshToken);
			if (result == null)
				return CommandResult(OperationResult<LoginResultDto?>.NotFound());
			if(result.TokenExpireDate > DateTime.Now)
				return CommandResult(OperationResult<LoginResultDto?>.Error("توکن هنوز منقضی نشده است."));
			if (result.RefreshTokenExpireDate < DateTime.Now)
				return CommandResult(OperationResult<LoginResultDto?>.Error("زمان رفرش توکن تمام شده است."));

			var user = await _userFacade.GetUserById(result.UserId);
			await _userFacade.RemoveToken(new RemoveUserTokenCommand(result.UserId,result.Id));

			var tokenResult = await AddTokenAndGenerateJwt(user);
			return CommandResult(tokenResult);
		}

		private async Task<OperationResult<LoginResultDto?>> AddTokenAndGenerateJwt(UserDto user)
		{
			var token = JwTokenBuilder.BuildToken(user, _configuration);
			var refreshToken = Guid.NewGuid().ToString();

			var hashJwt = Sha256Hasher.Hash(token);
			var hashRefreshToken = Sha256Hasher.Hash(refreshToken);

			var uaParser = Parser.GetDefault();
			var header = HttpContext.Request.Headers["user-agent"].ToString();
			var device = "windows";
			if (header != null)
			{
				var info = uaParser.Parse(header);
				device = $"{info.Device.Family}/{info.OS.Family} {info.OS.Major}.{info.OS.Minor} - {info.UA.Family}";
			}

			var tokenResult = await _userFacade.AddToken(new AddUserTokenCommand(user.Id, hashJwt, hashRefreshToken,
				DateTime.Now.AddDays(7), DateTime.Now.AddDays(8), device));

			if (tokenResult.Status != OperationResultStatus.Success)
				return OperationResult<LoginResultDto?>.Error();
			
			return OperationResult<LoginResultDto?>.Success(new LoginResultDto()
			{
				Token = token,
				RefrehToken = refreshToken
			});
		}
	}
}
