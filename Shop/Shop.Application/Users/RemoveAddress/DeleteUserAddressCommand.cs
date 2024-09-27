using Common.L2.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Users.RemoveAddress
{
	public record DeleteUserAddressCommand(long UserId, long AddressId) : IBaseCommand;
}
