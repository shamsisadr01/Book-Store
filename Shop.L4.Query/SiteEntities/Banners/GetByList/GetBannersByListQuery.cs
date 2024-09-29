using Common.L4.Query;
using Shop.L1.Domain.SiteEntities;
using Shop.L4.Query.SiteEntities._DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L4.Query.SiteEntities.Banners.GetByList
{
	public record GetBannersByListQuery : IQuery<List<BannerDto>>;
}
