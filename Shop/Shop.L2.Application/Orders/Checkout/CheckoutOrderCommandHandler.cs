using Common.L2.Application;
using Shop.L1.Domain.Order_Aggregate;
using Shop.L1.Domain.Order_Aggregate.Repository;
using Shop.L1.Domain.Order_Aggregate.ValeObjects;
using Shop.L1.Domain.SiteEntities.Repositories;


namespace Shop.L2.Application.Orders.Checkout
{
	public class CheckoutOrderCommandHandler : IBaseCommandHandler<CheckoutOrderCommand>
	{
		private readonly IOrderRepository _repository;
		private IShippingMethodRepository _shippingMethodRepository;
		public CheckoutOrderCommandHandler(IOrderRepository repository, IShippingMethodRepository shippingMethodRepository)
		{
			_repository = repository;
			_shippingMethodRepository = shippingMethodRepository;
		}

		public async Task<OperationResult> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
		{
			var currentOrder = await _repository.GetCurrentUserOrder(request.UserID);
			if (currentOrder == null)
				return OperationResult.NotFound();

			var address = new OrderAddress(request.Shire, request.City, request.PostalCode,
				request.PostalAddress, request.PhoneNumber, request.Name,
				request.Family, request.NationalCode);

			var shippingMethod = await _shippingMethodRepository.GetAsync(request.ShippingMethodId);
			if (shippingMethod == null)
				return OperationResult.Error();


			currentOrder.Checkout(address, new OrderShippingMethod(shippingMethod.Title, shippingMethod.Cost));

			await _repository.Save();
			return OperationResult.Success();
		}
	}
}
