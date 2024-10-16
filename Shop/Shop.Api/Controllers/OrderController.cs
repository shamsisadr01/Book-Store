using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.L1.Domain.Order_Aggregate.Enums;
using Shop.L1.Domain.Role_Aggregate.Enums;
using Shop.L2.Application.Orders.AddItem;
using Shop.L2.Application.Orders.Checkout;
using Shop.L2.Application.Orders.DecreaseItemCount;
using Shop.L2.Application.Orders.IncreaseItemCount;
using Shop.L2.Application.Orders.RemoveItem;
using Shop.L4.Query.Orders.DTOs;
using Shop.L5.Presentation.Facade.Orders;

namespace Shop.Api.Controllers
{
	[Authorize]
	public class OrderController : ApiController
	{
		private readonly IOrderFacade _orderFacade;

		public OrderController(IOrderFacade orderFacade)
		{
			_orderFacade = orderFacade;
		}

		[HttpGet, PermissionChecker(Permission.Order_Management)]
		public async Task<ApiResult<OrderFilterResult>> GetOrdersByFilter([FromQuery]OrderFilterParams filterParams)
		{
			var result = await _orderFacade.GetOrdersByFilter(filterParams);
			return QueryResult(result);
		}

        [HttpGet("current/filter")]
        public async Task<ApiResult<OrderFilterResult>> GetUserOrdersByFilter(int pageId = 1,int take = 10,OrderStatus status = OrderStatus.Finally)
        {
            var result = await _orderFacade.GetOrdersByFilter(new OrderFilterParams()
            {
				PageId = pageId,
				Take = take,
				Status = status,
				UserId = User.GetUserId(),
				EndDate = null,
				StartDate = null
            });
            return QueryResult(result);
        }

        [HttpGet("current")]
		public async Task<ApiResult<OrderDto?>> GetCurrentOrder()
        {
            var id = User.GetUserId();

            var result = await _orderFacade.GetCurrentOrder(id);
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

        [HttpPut("SendOrder/{orderId}")]
        public async Task<ApiResult> SendOrder(long orderId)
        {
            var result = await _orderFacade.SendOrder(orderId);
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

		[HttpDelete("orderItem/{itemId}")]
		public async Task<ApiResult> RemoveOrderItem(long itemId)
		{
			var result = await _orderFacade.
				RemoveOrderItem(new RemoveOrderItemCommand(User.GetUserId(),itemId));
			return CommandResult(result);
		}
	}
}
