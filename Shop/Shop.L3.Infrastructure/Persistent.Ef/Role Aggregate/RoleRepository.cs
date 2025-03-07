﻿using Shop.L1.Domain.Role_Aggregate.Repository;
using Shop.L1.Domain.Role_Aggregate;
using Shop.L3.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.L1.Domain.SiteEntities;

namespace Shop.L3.Infrastructure.Persistent.Ef.Role_Aggregate
{
	internal class RoleRepository : BaseRepository<Role>, IRoleRepository
	{
		public RoleRepository(StoreContext context) : base(context)
		{
		}

        public void Delete(Role role)
        {
            _storeContext.Roles.Remove(role);
        }
    }
}
