using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shop.Domain.Seller_Aggregate.Services
{
	public interface ISellerDomainService
	{
		bool IsValidSellerInformation(Seller seller);

		bool NationalCodeExistInDataBase(string nationalCode);
	}
}
