using Shop.L1.Domain.Seller_Aggregate.Enums;
using Shop.L1.Domain.Seller_Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.L4.Query;
using Common.L4.Query.Filter;

namespace Shop.L4.Query.Sellers.DTOs
{
	public class SellerDto : BaseDto
	{
		public long UserId { get; set; }
		public string ShopName { get; set; }
		public string NationalCode { get; set; }
		public SellerStatus Status { get; set; }
	}

	public class SellerFilterResult : BaseFilter<SellerDto, SellerFilterParams>
	{

	}

	public class SellerFilterParams : BaseFilterParam
	{
		public string ShopName { get; set; }
		public string NationalCode { get; set; }
	}
}
