
using Common.L1.Domain;
using Shop.L1.Domain.Role_Aggregate.Enums;

namespace Shop.L1.Domain.Role_Aggregate
{
	public class RolePermission : BaseEntity
	{
		public RolePermission(Permission permission)
		{
			Permission = permission;
		}

		public long RoleId { get; internal set; }
		public Permission Permission { get; private set; }
	}
}
