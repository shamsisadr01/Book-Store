using Common.L2.Application;
using Shop.L2.Application.Roles.Create;
using Shop.L2.Application.Roles.Edit;
using Shop.L4.Query.Roles.DTOs;

namespace Shop.L5.Presentation.Facade.Roles;

public interface IRoleFacade
{
	Task<OperationResult> CreateRole(CreateRoleCommand command);
	Task<OperationResult> EditRole(EditRoleCommand command);
	Task<OperationResult> DeleteRole(long roleId);

	Task<RoleDto?> GetRoleById(long roleId);
	Task<List<RoleDto>> GetRoles();
}