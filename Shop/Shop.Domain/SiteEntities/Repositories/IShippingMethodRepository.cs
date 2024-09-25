using Common.Domain.Repository;
using Shop.L1.Domain.SiteEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L1.Domain.SiteEntities.Repositories
{
	public interface IShippingMethodRepository : IBaseRepository<ShippingMethod>
	{
		void Delete(ShippingMethod method);
	}
}
