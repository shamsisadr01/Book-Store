using Shop.L1.Domain.Category_Aggregate.Repository;
using Shop.L1.Domain.Category_Aggregate;
using Shop.L3.Infrastructure._Utilities;
using Microsoft.EntityFrameworkCore;

namespace Shop.L3.Infrastructure.Persistent.Ef.Category_Aggregate
{
	internal class CategoryRepository : BaseRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(StoreContext storeContext) : base(storeContext)
		{
		}

		public async Task<bool> DeleteCategory(long categoryId)
		{
			var category = await _storeContext.Categories
				.Include(c => c.Childs)
				.ThenInclude(c => c.Childs).FirstOrDefaultAsync(f => f.Id == categoryId);
			if (category == null)
				return false;


			var isExistProduct = await _storeContext.Products
				.AnyAsync(f => f.CategoryId == categoryId ||
							   f.SubCategoryId == categoryId ||
							   f.SecondarySubCategoryId == categoryId);

			if (isExistProduct)
				return false;

			if (category.Childs.Any(c => c.Childs.Any()))
			{
				_storeContext.RemoveRange(category.Childs.SelectMany(s => s.Childs));
			}
			_storeContext.RemoveRange(category.Childs);
			_storeContext.RemoveRange(category);
			return true;
		}
	}
}
