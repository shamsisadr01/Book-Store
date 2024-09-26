

using Common.L1.Domain;
using Common.L1.Domain.Exceptions;

namespace Shop.L1.Domain.Role_Aggregate
{
	public class Role : AggregateRoot
	{
		private Role()
		{

		}
		public Role(string title, List<RolePermission> permissions)
		{
			NullOrEmptyDomainDataException.CheckString(title, nameof(title));
			Title = title;
			Permissions = permissions;
		}

		public Role(string title)
		{
			NullOrEmptyDomainDataException.CheckString(title, nameof(title));
			Title = title;
			Permissions = new List<RolePermission>();
		}

		public string Title { get; private set; }

		public List<RolePermission> Permissions { get; private set; }

		public void Edit(string title)
		{
			NullOrEmptyDomainDataException.CheckString(title, nameof(title));
			Title = title;
		}

		public void SetPermissions(List<RolePermission> permissions)
		{
			Permissions = permissions;
		}
	}
}
