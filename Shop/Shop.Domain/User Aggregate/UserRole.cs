using Common.Domain;

namespace _1.Shop.Domain.User_Aggregate
{
	public class UserRole : BaseEntity
	{
		public UserRole(long roleId)
		{
			RoleId = roleId;
		}

		public long UserId { get; internal set; }
		public long RoleId { get; private set; }
	}

}
