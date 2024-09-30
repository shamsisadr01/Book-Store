using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L4.Query.Products.GetByFilter
{
	public class GetProductsByFilterQueryHandler : IQueryHandler<GetProductsByFilterQuery, ProductFilterResult>
	{
		private readonly StoreContext _context;

		public GetProductsByFilterQueryHandler(StoreContext context)
		{
			_context = context;
		}

		public async Task<ProductFilterResult> Handle(GetProductsByFilterQuery request, CancellationToken cancellationToken)
		{
			var @params = request.FilterParamses;
			var result = _context.Products.OrderByDescending(d => d.Id).AsQueryable();

			if (!string.IsNullOrWhiteSpace(@params.Slug))
				result = result.Where(r => r.Slug == @params.Slug);

			if (!string.IsNullOrWhiteSpace(@params.Title))
				result = result.Where(r => r.Title.Contains(@params.Title));

			if (@params.Id != null)
				result = result.Where(r => r.Id == @params.Id);

			var skip = (@params.PageId - 1) * @params.Take;
			var model = new ProductFilterResult()
			{
				Data = await result.Skip(skip).Take(@params.Take).Select(s => s.MapListData())
					.ToListAsync(cancellationToken),
				FilterParams = @params
			};
			model.GeneratePaging(result, @params.Take, @params.PageId);
			return model;
		}
	}
}
