using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.L4.Query;
using Shop.L4.Query.Orders.DTOs;

namespace Shop.L4.Query.Orders.GetCurrent
{
	public record GetCurrentUserOrderQuery(long UserId) : IQuery<OrderDto?>;
}
