using Common.L4.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L4.Query.SiteEntities._DTOs
{
	public class SliderDto : BaseDto
	{
		public string Title { get;  set; }
		public string Link { get;  set; }
		public string ImageName { get;  set; }
	}
}
