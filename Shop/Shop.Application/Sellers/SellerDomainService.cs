using Shop.L1.Domain.Seller_Aggregate;
using Shop.L1.Domain.Seller_Aggregate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Sellers
{
	public class SellerDomainService : ISellerDomainService
	{
		public bool IsValidSellerInformation(Seller seller)
		{
			throw new NotImplementedException();
		}

		public bool NationalCodeExistInDataBase(string nationalCode)
		{
			throw new NotImplementedException();
		}
	}
}
