﻿using Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shop.Domain.SiteEntities.Repositories
{
	public interface IShippingMethodRepository : IBaseRepository<ShippingMethod>
	{
		void Delete(ShippingMethod method);
	}
}
