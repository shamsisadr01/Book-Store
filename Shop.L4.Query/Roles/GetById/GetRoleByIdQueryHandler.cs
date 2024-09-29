using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.Roles.DTOs;

namespace Shop.L4.Query.Roles.GetById
{
	public class GetRoleByIdQueryHandler : IQueryHandler<GetRoleByIdQuery, RoleDto?>
	{
		private readonly StoreContext _storeContext;

		public GetRoleByIdQueryHandler(StoreContext storeContext)
		{
			_storeContext = storeContext;
		}

		public async Task<RoleDto?> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
		{
			var role = await _storeContext.Roles.FirstOrDefaultAsync(r => r.Id == request.roleId, cancellationToken);
			if (role == null)
				return null;

			return new RoleDto()
			{
				Id = role.Id,
				CreationDate = role.CreationDate,
				Title = role.Title,
				Permissions = role.Permissions.Select(x => x.Permission).ToList(),
			};
		}
	}
}
