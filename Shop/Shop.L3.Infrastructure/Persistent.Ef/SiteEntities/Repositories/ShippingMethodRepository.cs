using Shop.L1.Domain.SiteEntities;
using Shop.L1.Domain.SiteEntities.Repositories;
using Shop.L3.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L3.Infrastructure.Persistent.Ef.SiteEntities.Repositories
{
	public class ShippingMethodRepository : BaseRepository<ShippingMethod>, IShippingMethodRepository
	{
		public ShippingMethodRepository(StoreContext storeContext) : base(storeContext)
		{
		}

		public void Delete(ShippingMethod method)
		{
			_storeContext.ShippingMethods.Remove(method);
		}
	}
}
