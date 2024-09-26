using Common.L2.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Products.AddImage
{
	public class AddProductImageCommand : IBaseCommand
	{
		public IFormFile ImageFile { get; set; }
		public long ProductId { get; set; }
		public int Sequence { get; set; }
	}
}
