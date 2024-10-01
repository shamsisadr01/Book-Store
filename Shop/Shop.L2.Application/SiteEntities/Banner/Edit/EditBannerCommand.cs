using Common.L2.Application;
using Microsoft.AspNetCore.Http;
using Shop.L1.Domain.SiteEntities;

namespace Shop.L2.Application.SiteEntities.Banner.Edit
{
	public class EditBannerCommand : IBaseCommand
	{
		public long Id { get; set; }
		public string Link { get; set; }
		public IFormFile? ImageFile { get; set; }
		public BannerPosition Position { get; set; }
	}
}
