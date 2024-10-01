using Common.L4.Query;
using Shop.L4.Query.SiteEntities.Banners.GetByList;
using Shop.L4.Query.SiteEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L4.Query.SiteEntities.Sliders.GetByList
{
	public record GetSlidersByListQuery : IQuery<List<SliderDto>>;
}
