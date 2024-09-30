using Common.L2.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Orders.RemoveItem
{
	public record RemoveOrderItemCommand(long userId,long itemId) : IBaseCommand;
}
