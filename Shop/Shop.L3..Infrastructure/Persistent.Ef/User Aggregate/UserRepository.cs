using _1.Shop.Domain.User_Aggregate;
using Shop.L1.Domain.User_Aggregate;
using Shop.L1.Domain.User_Aggregate.Repository;
using Shop.L3.Infrastructure._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L3.Infrastructure.Persistent.Ef.User_Aggregate
{
	internal class UserRepository : BaseRepository<User>, IUserRepository
	{
		public UserRepository(StoreContext context) : base(context)
		{
		}
	}
}
