using Common.L2.Application;
using Shop.L2.Application.Sellers.Create;
using Shop.L2.Application.Sellers.Edit;
using Shop.L4.Query.Sellers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L5.Presentation.Facade.Sellers
{
	public interface ISellerFacade
	{
		Task<OperationResult> CreateSeller(CreateSellerCommand command);
		Task<OperationResult> EditSeller(EditSellerCommand command);
		Task<SellerDto?> GetSellerById(long sellerId);
		Task<SellerFilterResult> GetSellersByFilter(SellerFilterParams filterParams);
	}
}
