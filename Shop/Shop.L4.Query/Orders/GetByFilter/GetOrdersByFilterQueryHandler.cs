using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.Orders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L4.Query.Orders.GetByFilter
{
	public class GetOrdersByFilterQueryHandler : IQueryHandler<GetOrdersByFilterQuery, OrderFilterResult>
	{
		private readonly StoreContext _context;

		public GetOrdersByFilterQueryHandler(StoreContext context)
		{
			_context = context;
		}
		public async Task<OrderFilterResult> Handle(GetOrdersByFilterQuery request, CancellationToken cancellationToken)
		{
			var @params = request.FilterParams;
			var result = _context.Orders.OrderByDescending(d => d.Id).AsQueryable();

			if (@params.Status != null)
				result = result.Where(r => r.Status == @params.Status);

			if (@params.UserId != null)
				result = result.Where(r => r.UserId == @params.UserId);

			if (@params.StartDate != null)
				result = result.Where(r => r.CreationDate.Date >= @params.StartDate.Value.Date);

			if (@params.EndDate != null)
				result = result.Where(r => r.CreationDate.Date <= @params.EndDate.Value.Date);


			var skip = (@params.PageId - 1) * @params.Take;
			var model = new OrderFilterResult()
			{
				Data = await result.Skip(skip).Take(@params.Take)
					.Select(order => order.MapFilterData(_context))
					.ToListAsync(cancellationToken),
				FilterParams = @params
			};
			model.GeneratePaging(result, @params.Take, @params.PageId);
			return model;
		}
	}
}
