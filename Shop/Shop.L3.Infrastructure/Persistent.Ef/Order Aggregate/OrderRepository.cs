using Microsoft.EntityFrameworkCore;
using Shop.L1.Domain.Order_Aggregate;
using Shop.L1.Domain.Order_Aggregate.Enums;
using Shop.L3.Infrastructure._Utilities;
using Shop.L1.Domain.Order_Aggregate.Repository;

namespace Shop.L3.Infrastructure.Persistent.Ef.Order_Aggregate
{
	public class OrderRepository : BaseRepository<Order>, IOrderRepository
	{
		public OrderRepository(StoreContext storeContext) : base(storeContext)
		{
		}

		public async Task<Order?> GetCurrentUserOrder(long userId)
		{
			return await _storeContext.Orders.AsTracking()
				.FirstOrDefaultAsync(f => f.UserId == userId && f.Status == OrderStatus.Pending);
		}
	}
}
