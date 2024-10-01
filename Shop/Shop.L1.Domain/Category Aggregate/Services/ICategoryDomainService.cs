

namespace Shop.L1.Domain.Category_Aggregate.Services
{
	public interface ICategoryDomainService
	{
		bool IsSlugExist(string slug);
	}
}
