using Common.L2.Application;
using Shop.L1.Domain.Role_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Roles.Edit
{
	public record EditRoleCommand(long Id, string Title, List<Permission> Permissions) : IBaseCommand;

}
