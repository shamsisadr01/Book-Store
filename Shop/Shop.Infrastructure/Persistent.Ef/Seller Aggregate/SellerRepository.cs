using Shop.L1.Domain.Seller_Aggregate.Repository;
using Shop.L1.Domain.Seller_Aggregate;
using Shop.L3.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shop.L3.Infrastructure.Persistent.Ef.Seller_Aggregate
{
	internal class SellerRepository : BaseRepository<Seller>, ISellerRepository
	{
		public SellerRepository(StoreContext storeContext) : base(storeContext)
		{
		}

		public async Task<InventoryResult?> GetInventoryById(long id)
		{
		    return await _storeContext.Inventories.Where(r => r.Id==id)
		        .Select(i=>new InventoryResult()
		        {
		            Count = i.Count,
		            Id = i.Id,
		           Price = i.Price,
		            ProductId = i.ProductId,
		           SellerId = i.SellerId
		      }).FirstOrDefaultAsync();
		}
	}
}
