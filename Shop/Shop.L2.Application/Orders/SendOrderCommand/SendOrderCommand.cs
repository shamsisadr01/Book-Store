using Common.L2.Application;
using Shop.L1.Domain.Order_Aggregate.Enums;
using Shop.L1.Domain.Order_Aggregate.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Orders.SendOrderCommand
{
	public class SendOrderCommand : IBaseCommand
	{
		public SendOrderCommand(long orderId)
		{
			OrderId = orderId;
		}

		public long OrderId { get; private set; }
	}

	public class SendOrderCommandHandler : IBaseCommandHandler<SendOrderCommand>
	{
		private readonly IOrderRepository _orderRepository;

		public SendOrderCommandHandler(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public async Task<OperationResult> Handle(SendOrderCommand request, CancellationToken cancellationToken)
		{
			var order = await _orderRepository.GetTracking(request.OrderId);
			if (order == null)
				return OperationResult.NotFound();

			order.ChangeStatus(OrderStatus.Shipping);
			await _orderRepository.Save();
			return OperationResult.Success();
		}
	}
}
