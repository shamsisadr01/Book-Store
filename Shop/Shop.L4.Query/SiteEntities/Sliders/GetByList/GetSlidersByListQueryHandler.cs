using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.SiteEntities.DTOs;

namespace Shop.L4.Query.SiteEntities.Sliders.GetByList
{
	public class GetSlidersByListQueryHandler : IQueryHandler<GetSlidersByListQuery, List<SliderDto>>
	{
		private readonly StoreContext _storeContext;

		public GetSlidersByListQueryHandler(StoreContext storeContext)
		{
			_storeContext = storeContext;
		}

		public async Task<List<SliderDto>> Handle(GetSlidersByListQuery request, CancellationToken cancellationToken)
		{
			return await _storeContext.Sliders.OrderByDescending(b => b.Id)
					.Select(b => new SliderDto()
					{
						Id = b.Id,
						CreationDate = b.CreationDate,
						ImageName = b.ImageName,
						Link = b.Link,
						Title = b.Title,
			}).ToListAsync(cancellationToken);
		}
	}
}
