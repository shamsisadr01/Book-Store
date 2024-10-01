using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.Categories.DTOs;


namespace Shop.L4.Query.Categories.GetList
{
	internal class GetCategoryListQueryHandler : IQueryHandler<GetCategoryListQuery, List<CategoryDto>>
	{
		private readonly StoreContext _context;

		public GetCategoryListQueryHandler(StoreContext context)
		{
			_context = context;
		}

		public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
		{
			var model = await _context.Categories
				.Where(r => r.ParentId == null)
				.Include(c => c.Childs)
				.ThenInclude(c => c.Childs)
				.OrderByDescending(d => d.Id).ToListAsync(cancellationToken);
			return model.Map();
		}
	}
}
