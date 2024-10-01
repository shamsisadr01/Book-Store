using Common.L1.Domain.ValueObjects;
using Common.L4.Query;
using Shop.L1.Domain.Category_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L4.Query.Categories.DTOs
{
	public class CategoryDto : BaseDto
	{
		public string Title { get; set; }
		public string Slug { get;  set; }
		public SeoData SeoData { get;  set; }
		public List<SubCategoryDto> Childs { get; set; }
	}
}
