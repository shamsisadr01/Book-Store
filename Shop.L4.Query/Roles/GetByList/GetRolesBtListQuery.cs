using Common.L4.Query;
using Shop.L4.Query.Roles.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L4.Query.Roles.GetByList
{
	public record GetRolesBtListQuery:IQuery<List<RoleDto>>;
}
