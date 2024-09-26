using Common.L2.Application;
using Shop.L1.Domain.Seller_Aggregate.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Sellers.Edit
{
	public record EditSellerCommand(long Id, string ShopName, string NationalCode, SellerStatus Status) : IBaseCommand;
}
