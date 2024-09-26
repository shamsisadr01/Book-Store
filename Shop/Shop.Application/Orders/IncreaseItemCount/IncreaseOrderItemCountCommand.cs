using Common.L2.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Orders.IncreaseItemCount
{
	public record IncreaseOrderItemCountCommand(long userId,long itemId,int count) : IBaseCommand;
}
