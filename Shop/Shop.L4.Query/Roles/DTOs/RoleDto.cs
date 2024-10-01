using Common.L4.Query;
using Shop.L1.Domain.Role_Aggregate.Enums;

namespace Shop.L4.Query.Roles.DTOs
{
	public class RoleDto : BaseDto
	{
		public string Title { get;  set; }

		public List<Permission> Permissions { get;  set; }
	}
}
