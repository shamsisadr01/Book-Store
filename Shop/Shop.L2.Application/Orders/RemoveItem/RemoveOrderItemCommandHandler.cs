﻿using Common.L2.Application;
using Shop.L1.Domain.Order_Aggregate.Repository;

namespace Shop.L2.Application.Orders.RemoveItem;

public class RemoveOrderItemCommandHandler : IBaseCommandHandler<RemoveOrderItemCommand>
{
	private readonly IOrderRepository _orderRepository;

	public RemoveOrderItemCommandHandler(IOrderRepository orderRepository)
	{
		_orderRepository = orderRepository;
	}

	public async Task<OperationResult> Handle(RemoveOrderItemCommand request, CancellationToken cancellationToken)
	{
		var currentOrder = await _orderRepository.GetCurrentUserOrder(request.userId);
		if (currentOrder == null)
			return OperationResult.NotFound();

		currentOrder.RemoveItem(request.itemId);
		await _orderRepository.Save();
		return OperationResult.Success();
	}
}