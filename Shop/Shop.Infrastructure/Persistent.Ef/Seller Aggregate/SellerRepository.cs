using Shop.L1.Domain.Seller_Aggregate.Repository;
using Shop.L1.Domain.Seller_Aggregate;
using Shop.L3.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Dapper;
using Dapper;

namespace Shop.L3.Infrastructure.Persistent.Ef.Seller_Aggregate
{
	internal class SellerRepository : BaseRepository<Seller>, ISellerRepository
	{
		private readonly DapperContext _dapperContext;

		public SellerRepository(StoreContext storeContext, DapperContext dapperContext) : base(storeContext)
		{
			_dapperContext = dapperContext;
		}

		/*public async Task<InventoryResult?> GetInventoryById(long id)
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
		}*/

		public async Task<InventoryResult?> GetInventoryById(long id)
		{
			using var connection = _dapperContext.CreateConnection;
			var sql = $"SELECT * from {_dapperContext.Inventories} where Id=@InventoryId";

			return await connection.QueryFirstOrDefaultAsync<InventoryResult>
		   (sql, new { InventoryId = id });
		}
	}
}
