using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.Roles.DTOs;

namespace Shop.L4.Query.Roles.GetByList
{
	public class GetRolesBtListQueryHandler : IQueryHandler<GetRolesBytListQuery, List<RoleDto>>
	{
		private readonly StoreContext _storeContext;

		public GetRolesBtListQueryHandler(StoreContext storeContext)
		{
			_storeContext = storeContext;
		}
		public async Task<List<RoleDto>> Handle(GetRolesBytListQuery request, CancellationToken cancellationToken)
		{
			return await _storeContext.Roles.Select(r => new RoleDto
			{
				Id = r.Id,
				CreationDate = r.CreationDate,
				Title = r.Title,
				Permissions = r.Permissions.Select(r=>r.Permission).ToList(),
			}).ToListAsync(cancellationToken);
		}
	}
}
