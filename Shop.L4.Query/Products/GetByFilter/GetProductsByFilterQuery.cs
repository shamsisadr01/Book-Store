using Common.L4.Query;
using Shop.L4.Query.Products.DTOs;

namespace Shop.L4.Query.Products.GetByFilter
{
	public class GetProductsByFilterQuery : QueryFilter<ProductFilterResult, ProductFilterParams>
	{
		public GetProductsByFilterQuery(ProductFilterParams filterParams) : base(filterParams)
		{
		}
	}
}
