using Common.L2.Application;

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
}
