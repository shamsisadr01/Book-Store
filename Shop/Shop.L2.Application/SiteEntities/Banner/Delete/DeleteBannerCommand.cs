using Common.L2.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L4.Query.SiteEntities.Banners.Delete
{
    public record DeleteBannerCommand(long Id) : IBaseCommand;
}
