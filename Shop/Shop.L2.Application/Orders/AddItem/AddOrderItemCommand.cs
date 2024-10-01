using Common.L2.Application;

namespace Shop.L2.Application.Orders.AddItem
{
	public class AddOrderItemCommand : IBaseCommand
	{
		public AddOrderItemCommand(long inventoryId, int count, int userID)
		{
			InventoryId = inventoryId;
			Count = count;
			UserId = userID;
		}

		public long InventoryId { get; private set; }
		public int Count {  get;private set; }
		public long UserId {  get; private set; }
	}
}
