using Common.L4.Query;
using Shop.L1.Domain.SiteEntities;

namespace Shop.L4.Query.SiteEntities.DTOs
{
	public class BannerDto : BaseDto
	{
		public string Link { get; set; }
		public string ImageName { get; set; }
		public BannerPosition Position { get; set; }
	}
}
