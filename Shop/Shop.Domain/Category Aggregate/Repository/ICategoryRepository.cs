using Common.L1.Domain.Repository;

namespace Shop.L1.Domain.Category_Aggregate.Repository
{
	public interface ICategoryRepository : IBaseRepository<Category>
	{
		Task<bool> DeleteCategory(long categoryId);
	}
}
