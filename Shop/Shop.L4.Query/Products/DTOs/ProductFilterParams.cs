using Common.L4.Query.Filter;

namespace Shop.L4.Query.Products.DTOs
{
	public class ProductFilterParams : BaseFilterParam
	{
		public string? Title { get; set; }
		public long? Id {  get; set; }
		public string? Slug { get; set; }
	}
}
