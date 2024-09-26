using Common.L1.Domain.Repository;

namespace Shop.L1.Domain.Order_Aggregate.Repositories
{
	public interface IOrderRepository : IBaseRepository<Order>
	{
		Task<Order> GetCurrentUserOrder(long userId);
	}
}
