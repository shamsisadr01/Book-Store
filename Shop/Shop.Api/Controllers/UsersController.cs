using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.L1.Domain.Role_Aggregate.Enums;
using Shop.L2.Application.Users.Create;
using Shop.L2.Application.Users.Edit;
using Shop.L4.Query.Users.DTOs;
using Shop.L5.Presentation.Facade.Users;

namespace Shop.Api.Controllers
{
	[PermissionChecker(Permission.User_Management)]
	public class UsersController : ApiController
	{
		private readonly IUserFacade _userFacade;
		public UsersController(IUserFacade userFacade)
		{
			_userFacade = userFacade;
		}
		[HttpGet]
		public async Task<ApiResult<UserFilterResult>> GetUsers(UserFilterParams filterParams)
		{
			var result = await _userFacade.GetUserByFilter(filterParams);
			return QueryResult(result);
		}
		[HttpGet("{userId}")]
		public async Task<ApiResult<UserDto?>> GetById(long userId)
		{
			var result = await _userFacade.GetUserById(userId);
			return QueryResult(result);
		}
		[HttpPost]
		public async Task<ApiResult> Create(CreateUserCommand command)
		{
			var result = await _userFacade.CreateUser(command);
			return CommandResult(result);
		}
		[HttpPut]
		public async Task<ApiResult> Edit(EditUserCommand command)
		{
			var result = await _userFacade.EditUser(command);
			return CommandResult(result);
		}
	}
}
