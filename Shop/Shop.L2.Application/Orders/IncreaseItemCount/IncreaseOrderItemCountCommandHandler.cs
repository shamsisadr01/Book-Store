using Common.L2.Application;
using Shop.L1.Domain.Order_Aggregate.Repository;

namespace Shop.L2.Application.Orders.IncreaseItemCount
{
	public class IncreaseOrderItemCountCommandHandler : IBaseCommandHandler<IncreaseOrderItemCountCommand>
	{
		private readonly IOrderRepository _orderRepository;

		public IncreaseOrderItemCountCommandHandler(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public async Task<OperationResult> Handle(IncreaseOrderItemCountCommand request, CancellationToken cancellationToken)
		{
			var currentOrder = await _orderRepository.GetCurrentUserOrder(request.userId);
			if (currentOrder == null)
				return OperationResult.NotFound();

			currentOrder.IncreaseItemCount(request.itemId, request.count);
			await _orderRepository.Save();
			return OperationResult.Success();
		}
	}
}
