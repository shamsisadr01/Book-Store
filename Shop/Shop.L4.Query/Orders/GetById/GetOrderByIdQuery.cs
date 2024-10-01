using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Dapper;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.Orders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L4.Query.Orders.GetById
{
	public record GetOrderByIdQuery(long orderId) : IQuery<OrderDto?>;

	public class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDto?>
	{
		private readonly StoreContext _storeContext;
		private readonly DapperContext _dapperContext;

		public GetOrderByIdQueryHandler(StoreContext storeContext, DapperContext dapperContext)
		{
			_storeContext = storeContext;
			_dapperContext = dapperContext;
		}

		public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
		{
			var order = await _storeContext.Orders.FirstOrDefaultAsync(o => o.Id == request.orderId);
			if (order == null)
				return null;
			var orderDto = order.Map();
			orderDto.UserFullName = await _storeContext.Users.Where(f => f.Id == order.Id)
				.Select(s =>$"{s.Name} {s.Family}").FirstAsync();

			orderDto.Items = await orderDto.GetOrderItems(_dapperContext);

			return orderDto;
		}
	}
}
