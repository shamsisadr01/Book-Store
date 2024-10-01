using Common.L2.Application;
using Shop.L1.Domain.Role_Aggregate.Enums;

namespace Shop.L2.Application.Roles.Edit
{
	public record EditRoleCommand(long Id, string Title, List<Permission> Permissions) : IBaseCommand;

}
