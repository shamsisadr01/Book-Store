using Common.L4.Query;
using Shop.L4.Query.Products.DTOs;

namespace Shop.L4.Query.Products.GetForShop;

public class GetProductsForShopQuery : QueryFilter<ProductShopResult, ProductShopFilterParam>
{
	public GetProductsForShopQuery(ProductShopFilterParam filterParams) : base(filterParams)
	{
	}
}