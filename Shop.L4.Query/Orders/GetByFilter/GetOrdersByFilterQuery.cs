using Common.L4.Query;
using Shop.L4.Query.Orders.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L4.Query.Orders.GetByFilter
{
	public class GetOrdersByFilterQuery : QueryFilter<OrderFilterResult, OrderFilterParams>
	{
		public GetOrdersByFilterQuery(OrderFilterParams filterParams) : base(filterParams)
		{
		}
	}
}
