using Common.L2.Application;
using MediatR;
using Shop.L2.Application.Orders.AddItem;
using Shop.L2.Application.Orders.Checkout;
using Shop.L2.Application.Orders.DecreaseItemCount;
using Shop.L2.Application.Orders.Finally;
using Shop.L2.Application.Orders.IncreaseItemCount;
using Shop.L2.Application.Orders.RemoveItem;
using Shop.L2.Application.Orders.SendOrderCommand;
using Shop.L4.Query.Orders.DTOs;
using Shop.L4.Query.Orders.GetByFilter;
using Shop.L4.Query.Orders.GetById;
using Shop.L4.Query.Orders.GetCurrent;

namespace Shop.L5.Presentation.Facade.Orders;

public class OrderFacade : IOrderFacade
{
	private readonly IMediator _mediator;

	public OrderFacade(IMediator mediator)
	{
		_mediator = mediator;
	}

	public async Task<OperationResult> AddOrderItem(AddOrderItemCommand command)
	{
		return await _mediator.Send(command);
	}

	public async Task<OperationResult> RemoveOrderItem(RemoveOrderItemCommand command)
	{
		return await _mediator.Send(command);
	}

	public async Task<OperationResult> OrderCheckout(CheckoutOrderCommand command)
	{
		return await _mediator.Send(command);
	}

	public async Task<OperationResult> IncreaseItemCount(IncreaseOrderItemCountCommand command)
	{
		return await _mediator.Send(command);
	}

	public async Task<OperationResult> DecreaseItemCount(DecreaseOrderItemCountCommand command)
	{
		return await _mediator.Send(command);
	}

	public async Task<OperationResult> FinallyOrder(OrderFinallyCommand command)
	{
		return await _mediator.Send(command);
	}

	public async Task<OperationResult> SendOrder(long orderId)
	{
		return await _mediator.Send(new SendOrderCommand(orderId));
	}

	public async Task<OrderDto?> GetOrderById(long orderId)
	{
		return await _mediator.Send(new GetOrderByIdQuery(orderId));
	}

	public async Task<OrderFilterResult> GetOrdersByFilter(OrderFilterParams filterParams)
	{
		return await _mediator.Send(new GetOrdersByFilterQuery(filterParams));
	}

	public async Task<OrderDto?> GetCurrentOrder(long userId)
	{
		return await _mediator.Send(new GetCurrentUserOrderQuery(userId));
	}
}