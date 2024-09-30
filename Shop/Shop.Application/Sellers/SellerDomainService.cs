using Shop.L1.Domain.Seller_Aggregate;
using Shop.L1.Domain.Seller_Aggregate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.L1.Domain.Seller_Aggregate.Repository;

namespace Shop.L2.Application.Sellers
{
	public class SellerDomainService : ISellerDomainService
	{
		private readonly ISellerRepository _repository;

		public SellerDomainService(ISellerRepository repository)
		{
			_repository = repository;
		}

		public bool IsValidSellerInformation(Seller seller)
		{
			var sellerIsExist = _repository.Exists(s => s.NationalCode == seller.NationalCode
			                                            || s.UserId == seller.UserId);
			return !sellerIsExist;
		}

		public bool NationalCodeExistInDataBase(string nationalCode)
		{
			return _repository.Exists(r => r.NationalCode == nationalCode);
		}
	}
}
