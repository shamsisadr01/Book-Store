

namespace Shop.L1.Domain.Product_Aggregate.Services
{
	public interface IProductDomainService
	{
		bool SlugIsExist(string slug);
	}
}
