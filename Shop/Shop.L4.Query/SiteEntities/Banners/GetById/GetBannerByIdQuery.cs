using Common.L4.Query;
using Shop.L4.Query.SiteEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L4.Query.SiteEntities.Banners.GetById
{
	public record GetBannerByIdQuery(long bannerId): IQuery<BannerDto>;
}
