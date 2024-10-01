using Common.L2.Application;
using Shop.L1.Domain.Order_Aggregate.Repository;

namespace Shop.L2.Application.Orders.DecreaseItemCount
{
	public class DecreaseOrderItemCountCommandHandler : IBaseCommandHandler<DecreaseOrderItemCountCommand>
	{
		private readonly IOrderRepository _orderRepository;

		public DecreaseOrderItemCountCommandHandler(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public async Task<OperationResult> Handle(DecreaseOrderItemCountCommand request, CancellationToken cancellationToken)
		{
			var currentOrder = await _orderRepository.GetCurrentUserOrder(request.userId);
			if (currentOrder == null)
				return OperationResult.NotFound();

			currentOrder.DecreaseItemCount(request.itemId, request.count);
			await _orderRepository.Save();
			return OperationResult.Success();
		}
	}
}
