using Common.L2.Application;
using Microsoft.AspNetCore.Http;

namespace Shop.L2.Application.SiteEntities.Sliders.Create
{
	public class CreateSliderCommand : IBaseCommand
	{
		public string Link { get; set; }
		public IFormFile ImageFile { get; set; }
		public string Title { get; set; }
	}
}
