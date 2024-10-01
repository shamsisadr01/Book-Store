using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L4.Query.Categories.GetByParentId
{
	internal class GetCategoryByParentIdQueryHandler : IQueryHandler<GetCategoryByParentIdQuery, List<SubCategoryDto>>
	{
		private readonly StoreContext _context;

		public GetCategoryByParentIdQueryHandler(StoreContext context)
		{
			_context = context;
		}

		public async Task<List<SubCategoryDto>> Handle(GetCategoryByParentIdQuery request, CancellationToken cancellationToken)
		{
			var result = await _context.Categories
				.Include(c => c.Childs)
				.Where(r => r.ParentId == request.ParentId).ToListAsync(cancellationToken);

			return result.MapChildren();
		}
	}
}
