using AutoMapper;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Api.ViewModels.Users;
using Shop.L1.Domain.Role_Aggregate.Enums;
using Shop.L2.Application.Users.ChangePassword;
using Shop.L2.Application.Users.Create;
using Shop.L2.Application.Users.Edit;
using Shop.L4.Query.Users.DTOs;
using Shop.L5.Presentation.Facade.Users;

namespace Shop.Api.Controllers
{
	[Authorize]
	public class UsersController : ApiController
	{
		private readonly IUserFacade _userFacade;
        private readonly IMapper _mapper;

		public UsersController(IUserFacade userFacade, IMapper mapper)
        {
            _userFacade = userFacade;
            _mapper = mapper;
        }
		[HttpGet]
		[PermissionChecker(Permission.User_Management)]
		public async Task<ApiResult<UserFilterResult>> GetUsers(UserFilterParams filterParams)
		{
			var result = await _userFacade.GetUserByFilter(filterParams);
			return QueryResult(result);
		}

		[HttpGet("Current")]
		public async Task<ApiResult<UserDto>> GetCurrentUser()
		{
			var result = await _userFacade.GetUserById(User.GetUserId());
			return QueryResult(result);
		}

		[HttpGet("{userId}")]
		[PermissionChecker(Permission.User_Management)]
		public async Task<ApiResult<UserDto?>> GetById(long userId)
		{
			var result = await _userFacade.GetUserById(userId);
			return QueryResult(result);
		}
		[HttpPost]
		[PermissionChecker(Permission.User_Management)]
		public async Task<ApiResult> Create(CreateUserCommand command)
		{
			var result = await _userFacade.CreateUser(command);
			return CommandResult(result);
		}

        [HttpPut("ChangePassword")]
        public async Task<ApiResult> ChangePassword(ChangePasswordViewModel viewModel)
        {
            var command = _mapper.Map<ChangeUserPasswordCommand>(viewModel);
			command.UserId = User.GetUserId();
            var result = await _userFacade.ChangePassword(command);
            return CommandResult(result);
        }

        [HttpPut("Current")]
        public async Task<ApiResult> EditUser([FromForm] EditUserViewModel viewModel)
        {
            var command = _mapper.Map<EditUserCommand>(viewModel);
			command.UserId = User.GetUserId();
            var result = await _userFacade.EditUser(command);
            return CommandResult(result);
        }

        [HttpPut]
		[PermissionChecker(Permission.User_Management)]
		public async Task<ApiResult> Edit([FromForm]EditUserCommand command)
		{
			var result = await _userFacade.EditUser(command);
			return CommandResult(result);
		}
	}
}
