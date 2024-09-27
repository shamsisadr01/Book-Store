using Common.L2.Application;
using Microsoft.AspNetCore.Http;
using Shop.L1.Domain.SiteEntities;

namespace Shop.L2.Application.SiteEntities.Banner.Create
{
	public class CreateBannerCommand : IBaseCommand
	{
		public string Link { get; set; }
		public IFormFile ImageFile { get; set; }
		public BannerPosition Position { get; set; }
	}
}
