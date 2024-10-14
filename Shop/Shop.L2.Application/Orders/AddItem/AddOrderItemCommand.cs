using Common.L2.Application;

namespace Shop.L2.Application.Orders.AddItem
{
	public class AddOrderItemCommand : IBaseCommand
	{

		public long InventoryId { get;  set; }
		public int Count {  get; set; }
		public long UserId {  get;  set; }
	}
}
