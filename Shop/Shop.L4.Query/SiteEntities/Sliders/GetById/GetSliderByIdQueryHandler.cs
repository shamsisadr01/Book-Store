using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.SiteEntities._DTOs;

namespace Shop.L4.Query.SiteEntities.Sliders.GetById
{
	public class GetSliderByIdQueryHandler : IQueryHandler<GetSliderByIdQuery, SliderDto>
	{
		private readonly StoreContext _storeContext;

		public GetSliderByIdQueryHandler(StoreContext storeContext)
		{
			_storeContext = storeContext;
		}

		public async Task<SliderDto> Handle(GetSliderByIdQuery request, CancellationToken cancellationToken)
		{
			var slider = await _storeContext.Sliders.FirstOrDefaultAsync(b => b.Id == request.sliderId, cancellationToken);
			if (slider == null)
				return null;
			return new SliderDto()
			{
				Id = slider.Id,
				CreationDate = slider.CreationDate,
				ImageName = slider.ImageName,
				Link = slider.Link,
				Title = slider.Title,
			};
		}
	}
}
