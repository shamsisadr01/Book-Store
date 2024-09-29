using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.SiteEntities._DTOs;

namespace Shop.L4.Query.SiteEntities.Banners.GetByList
{
	public class GetBannersByListQueryHandler : IQueryHandler<GetBannersByListQuery, List<BannerDto>>
	{
		private readonly StoreContext _storeContext;

		public GetBannersByListQueryHandler(StoreContext storeContext)
		{
			_storeContext = storeContext;
		}
		public async Task<List<BannerDto>> Handle(GetBannersByListQuery request, CancellationToken cancellationToken)
		{
			return await _storeContext.Banners.OrderByDescending(b => b.Id)
				.Select(b => new BannerDto()
				{
					Id = b.Id,
					CreationDate = b.CreationDate,
					ImageName = b.ImageName,
					Link = b.Link,
					Position = b.Position
				}).ToListAsync(cancellationToken);
		}
	}
}
