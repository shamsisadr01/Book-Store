using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.Categories.DTOs;

namespace Shop.L4.Query.Categories.GetById
{
	internal class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, CategoryDto>
	{
		private readonly StoreContext _storeContext;

		public GetCategoryByIdQueryHandler(StoreContext storeContext)
		{
			_storeContext = storeContext;
		}

		public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
		{
			var model = await _storeContext.Categories
		 .FirstOrDefaultAsync(f => f.Id == request.CategoryId, cancellationToken);
			return model.Map();
		}
	}
}
