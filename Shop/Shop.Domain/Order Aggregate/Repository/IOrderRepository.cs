using Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shop.Domain.Order_Aggregate.Repositories
{
	public interface IOrderRepository : IBaseRepository<Order>
	{
		Task<Order> GetCurrentUserOrder(long userId);
	}
}
