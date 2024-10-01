using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.L2.Application.Orders.AddItem;
using Shop.L2.Application.Orders.Checkout;
using Shop.L2.Application.Orders.DecreaseItemCount;
using Shop.L2.Application.Orders.IncreaseItemCount;
using Shop.L2.Application.Orders.RemoveItem;
using Shop.L4.Query.Orders.DTOs;
using Shop.L5.Presentation.Facade.Orders;

namespace Shop.Api.Controllers
{
	public class OrderController : ApiController
	{
		private readonly IOrderFacade _orderFacade;

		public OrderController(IOrderFacade orderFacade)
		{
			_orderFacade = orderFacade;
		}

		[HttpGet]
		public async Task<ApiResult<OrderFilterResult>> GetOrdersByFilter([FromQuery]OrderFilterParams filterParams)
		{
			var result = await _orderFacade.GetOrdersByFilter(filterParams);
			return QueryResult(result);
		}

		[HttpGet("{orderId}")]
		public async Task<ApiResult<OrderDto?>> GetOrderById(long orderId)
		{
			var result = await _orderFacade.GetOrderById(orderId);
			return QueryResult(result);
		}

		[HttpPost]
		public async Task<ApiResult> AddOrderItem(AddOrderItemCommand command)
		{
			var result = await _orderFacade.AddOrderItem(command);
			return CommandResult(result);
		}

		[HttpPost("Checkout")]
		public async Task<ApiResult> CheckoutOrder(CheckoutOrderCommand command)
		{
			var result = await _orderFacade.OrderCheckout(command);
			return CommandResult(result);
		}

		[HttpPut("orderItem/increaseCount")]
		public async Task<ApiResult> IncreaseItemCount(IncreaseOrderItemCountCommand command)
		{
			var result = await _orderFacade.IncreaseItemCount(command);
			return CommandResult(result);
		}

		[HttpPut("orderItem/decreaseCount")]
		public async Task<ApiResult> DecreaseItemCount(DecreaseOrderItemCountCommand command)
		{
			var result = await _orderFacade.DecreaseItemCount(command);
			return CommandResult(result);
		}

		[HttpDelete("orderItem")]
		public async Task<ApiResult> RemoveOrderItem(RemoveOrderItemCommand command)
		{
			var result = await _orderFacade.RemoveOrderItem(command);
			return CommandResult(result);
		}
	}
}
