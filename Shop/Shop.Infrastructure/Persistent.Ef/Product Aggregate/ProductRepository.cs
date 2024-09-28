using Shop.L1.Domain.Product_Aggregate;
using Shop.L1.Domain.Product_Aggregate.Repository;
using Shop.L3.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L3.Infrastructure.Persistent.Ef.Product_Aggregate
{
	public class ProductRepository : BaseRepository<Product>, IProductRepository
	{
		public ProductRepository(StoreContext storeContext) : base(storeContext)
		{
		}
	}
}
