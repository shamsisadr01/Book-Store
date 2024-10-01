
using Common.L2.Application;
using Shop.L2.Application.Orders.AddItem;
using Shop.L2.Application.Orders.Checkout;
using Shop.L2.Application.Orders.DecreaseItemCount;
using Shop.L2.Application.Orders.Finally;
using Shop.L2.Application.Orders.IncreaseItemCount;
using Shop.L2.Application.Orders.RemoveItem;
using Shop.L4.Query.Orders.DTOs;

namespace Shop.L5.Presentation.Facade.Orders
{
	public interface IOrderFacade
	{
		Task<OperationResult> AddOrderItem(AddOrderItemCommand  command);
		Task<OperationResult> RemoveOrderItem(RemoveOrderItemCommand command);

		Task<OperationResult> OrderCheckout(CheckoutOrderCommand command);
		Task<OperationResult> IncreaseItemCount(IncreaseOrderItemCountCommand command);
		Task<OperationResult> DecreaseItemCount(DecreaseOrderItemCountCommand command);

		Task<OperationResult> FinallyOrder(OrderFinallyCommand command);
		Task<OperationResult> SendOrder(long orderId);

		Task<OrderDto?> GetOrderById(long orderId);
		Task<OrderFilterResult> GetOrdersByFilter(OrderFilterParams filterParams);
		Task<OrderDto?> GetCurrentOrder(long userId);
	}
}
