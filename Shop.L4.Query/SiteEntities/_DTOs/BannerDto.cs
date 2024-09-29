using Common.L4.Query;
using Shop.L1.Domain.SiteEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L4.Query.SiteEntities._DTOs
{
	public class BannerDto : BaseDto
	{
		public string Link { get;  set; }
		public string ImageName { get;  set; }
		public BannerPosition Position { get;  set; }
	}
}
