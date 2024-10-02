using Common.AspNetCore;
using Common.L1.Domain.ValueObjects;
using Common.L2.Application;
using Common.L2.Application.SecurityUtil;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.JwtUtil;
using Shop.Api.ViewModels.Auth;
using Shop.L2.Application.Users.Create;
using Shop.L2.Application.Users.Register;
using Shop.L5.Presentation.Facade.Users;

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
		public async Task<ApiResult<string?>> Login(LoginViewModel loginViewModel)
		{
			if (ModelState.IsValid == false)
			{
				return new ApiResult<string?>()
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
				var result = OperationResult<string>.Error("کاربری با مشخصات وارد شده یافت نشد.");
				return CommandResult(result);
			}
			if (Sha256Hasher.IsCompare(user.Password, loginViewModel.Password) == false)
			{
				var result = OperationResult<string>.Error("کاربری با مشخصات وارد شده یافت نشد.");
				return CommandResult(result);
			}
			if (user.IsActive == false)
			{
				var result = OperationResult<string>.Error("حساب کاربری شما غیر فعال است.");
				return CommandResult(result);
			}

			var token = JwTokenBuilder.BuildToken(user, _configuration);
			return new ApiResult<string?>()
			{
				Data = token,
				IsSuccess = true,
				MetaData = new(),
			};
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
	}
}
