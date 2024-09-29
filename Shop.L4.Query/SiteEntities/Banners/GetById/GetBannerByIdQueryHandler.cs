using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.SiteEntities._DTOs;

namespace Shop.L4.Query.SiteEntities.Banners.GetById
{
	public class GetBannerByIdQueryHandler : IQueryHandler<GetBannerByIdQuery, BannerDto>
	{
		private readonly StoreContext _storeContext;

		public GetBannerByIdQueryHandler(StoreContext storeContext)
		{
			_storeContext = storeContext;
		}

		public async Task<BannerDto> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
		{
			var banner = await _storeContext.Banners.FirstOrDefaultAsync(b=>b.Id == request.bannerId, cancellationToken);
			if (banner == null)
				return null;
			return new BannerDto()
			{
				Id = banner.Id,
				CreationDate = banner.CreationDate,
				ImageName = banner.ImageName,
				Link = banner.Link,
				Position = banner.Position
			};
		}
	}
}
