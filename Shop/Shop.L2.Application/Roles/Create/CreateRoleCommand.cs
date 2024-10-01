
using Common.L2.Application;
using Shop.L1.Domain.Role_Aggregate.Enums;

namespace Shop.L2.Application.Roles.Create
{
	public record CreateRoleCommand(string Title, List<Permission> Permissions) : IBaseCommand;
}
