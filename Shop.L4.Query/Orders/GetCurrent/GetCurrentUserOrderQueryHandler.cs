using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L1.Domain.Order_Aggregate.Enums;
using Shop.L3.Infrastructure.Persistent.Dapper;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.Orders.DTOs;

namespace Shop.L4.Query.Orders.GetCurrent;

public class GetCurrentUserOrderQueryHandler : IQueryHandler<GetCurrentUserOrderQuery, OrderDto?>
{
	private readonly StoreContext _storeContext;
	private readonly DapperContext _dapperContext;

	public GetCurrentUserOrderQueryHandler(StoreContext storeContext, DapperContext dapperContext)
	{
		_storeContext = storeContext;
		_dapperContext = dapperContext;
	}
	public async Task<OrderDto?> Handle(GetCurrentUserOrderQuery request, CancellationToken cancellationToken)
	{
		var order = await _storeContext.Orders
			.FirstOrDefaultAsync(f => f.UserId == request.UserId && f.Status == OrderStatus.Pending, cancellationToken);
		if (order == null)
			return null;

		var orderDto = order.Map();
		orderDto.UserFullName = await _storeContext.Users.Where(f => f.Id == orderDto.UserId)
			.Select(s => $"{s.Name} {s.Family}").FirstAsync(cancellationToken);

		orderDto.Items = await orderDto.GetOrderItems(_dapperContext);
		return orderDto;
	}
}