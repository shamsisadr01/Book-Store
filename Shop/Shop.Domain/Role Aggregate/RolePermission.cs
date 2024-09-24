using Common.Domain;

namespace _1.Shop.Domain.Role_Aggregate
{
	public class RolePermission : BaseEntity
	{
		public long RoleId { get; private set; }
		public Permission Permission { get; private set; }
	}
}
