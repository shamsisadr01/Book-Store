using Common.L4.Query;

namespace Shop.L4.Query.Products.DTOs
{
	public class ProductFilterData : BaseDto
	{
		public string Title { get; set; }
		public string ImageName { get; set; }
		public string Slug { get; set; }
	}
}
