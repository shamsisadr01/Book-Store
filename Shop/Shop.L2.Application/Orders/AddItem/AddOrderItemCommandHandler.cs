﻿using Common.L2.Application;
using Shop.L1.Domain.Order_Aggregate;
using Shop.L1.Domain.Order_Aggregate.Repository;
using Shop.L1.Domain.Seller_Aggregate.Repository;

namespace Shop.L2.Application.Orders.AddItem
{
	public class AddOrderItemCommandHandler : IBaseCommandHandler<AddOrderItemCommand>
	{
		private readonly IOrderRepository _orderRepository;
		private readonly ISellerRepository _sellerRepository;

		public AddOrderItemCommandHandler(IOrderRepository orderRepository, ISellerRepository sellerRepository)
		{
			_orderRepository = orderRepository;
			_sellerRepository = sellerRepository;
		}

		public async Task<OperationResult> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
		{
			var inventory = await _sellerRepository.GetInventoryById(request.InventoryId);
			if (inventory == null)
				return OperationResult.NotFound();


			if (inventory.Count < request.Count)
				return OperationResult.Error("تعداد محصولات موجود کمتر از تعداد درخواستی است.");

			var order = await _orderRepository.GetCurrentUserOrder(request.UserId);
			if (order == null)
			{
				order = new Order(request.UserId);
				order.AddItem(new OrderItem(request.InventoryId, request.Count, inventory.Price));
				_orderRepository.Add(order);
			}
			else
			{
				order.AddItem(new OrderItem(request.InventoryId, request.Count, inventory.Price));
			}

			if (ItemCountBeggerThanInventoryCount(inventory, order))
				return OperationResult.Error("تعداد محصولات موجود کمتر از حد درخواستی است.");

			await _orderRepository.Save();
			return OperationResult.Success();
		}

		private bool ItemCountBeggerThanInventoryCount(InventoryResult inventory, Order order)
		{
			var orderItem = order.Items.First(f => f.InventoryId == inventory.Id);
			if (orderItem.Count > inventory.Count)
				return true;

			return false;
		}
	}
}
