using Common.L4.Query;
using Shop.L4.Query.Sellers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L4.Query.Sellers.GetById
{
	public record GetSellerByIdQuery(long sellerId) : IQuery<SellerDto?>;
}
