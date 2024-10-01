using Shop.L1.Domain.SiteEntities.Repositories;
using Shop.L1.Domain.SiteEntities;
using Shop.L3.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L3.Infrastructure.Persistent.Ef.SiteEntities.Repositories
{
	internal class SliderRepository : BaseRepository<Slider>, ISliderRepository
	{
		public SliderRepository(StoreContext context) : base(context)
		{
		}

		public void Delete(Slider slider)
		{
			_storeContext.Sliders.Remove(slider);
		}
	}
}
