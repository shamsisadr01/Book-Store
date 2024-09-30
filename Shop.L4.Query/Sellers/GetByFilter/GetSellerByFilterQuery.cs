using Common.L4.Query;
using Shop.L4.Query.Orders.DTOs;
using Shop.L4.Query.Sellers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L4.Query.Sellers.GetByFilter
{
	public class GetSellerByFilterQuery : QueryFilter<SellerFilterResult, SellerFilterParams>
	{
		public GetSellerByFilterQuery(SellerFilterParams filterParams) : base(filterParams)
		{
		}
	}
}
