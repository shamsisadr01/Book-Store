using Common.L2.Application;
using Shop.L1.Domain.Seller_Aggregate.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Sellers.EditInventory
{
	public class EditSellerInventoryCommandHandler : IBaseCommandHandler<EditSellerInventoryCommand>
	{
		private readonly ISellerRepository _repository;

		public EditSellerInventoryCommandHandler(ISellerRepository repository)
		{
			_repository = repository;
		}

		public async Task<OperationResult> Handle(EditSellerInventoryCommand request, CancellationToken cancellationToken)
		{
			var seller = await _repository.GetTracking(request.SellerId);
			if (seller == null)
				return OperationResult.NotFound();

			seller.EditInventory(request.InventoryId, request.Count, request.Price, request.DiscountPercentage);
			await _repository.Save();
			return OperationResult.Success();
		}
	}
}
