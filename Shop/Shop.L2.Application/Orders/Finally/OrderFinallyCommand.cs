using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.L2.Application;

namespace Shop.L2.Application.Orders.Finally
{
	public record OrderFinallyCommand(long orderId) : IBaseCommand;
}
