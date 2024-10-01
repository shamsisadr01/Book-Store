using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.L2.Application.Roles.Create;
using Shop.L2.Application.Roles.Edit;
using Shop.L4.Query.Roles.DTOs;
using Shop.L5.Presentation.Facade.Roles;

namespace Shop.Api.Controllers
{
	
	public class RoleController : ApiController
	{
		private readonly IRoleFacade _roleFacade;

		public RoleController(IRoleFacade roleFacade)
		{
			_roleFacade = roleFacade;
		}

		[HttpGet]
		public async Task<ApiResult<List<RoleDto>>> GetRolesByList()
		{
			var result = await _roleFacade.GetRoles();
			return QueryResult(result);
		}

		[HttpGet("{roleId}")]
		public async Task<ApiResult<RoleDto?>> GetRoleByID(long roleId)
		{
			var result = await _roleFacade.GetRoleById(roleId);
			return QueryResult(result);
		}

		[HttpPost]
		public async Task<ApiResult> CreateRole(CreateRoleCommand command)
		{
			var result = await _roleFacade.CreateRole(command);
			return CommandResult(result);
		}

		[HttpPut]
		public async Task<ApiResult> EditRole(EditRoleCommand command)
		{
			var result = await _roleFacade.EditRole(command);
			return CommandResult(result);
		}
	}
}
