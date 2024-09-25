using Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shop.Domain.Seller_Aggregate.Repository
{
	public interface ISellerRepository : IBaseRepository<Seller>
	{
		Task<InventoryResult?> GetInventoryById(long id);
	}
}
