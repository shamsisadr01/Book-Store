using _1.Shop.Domain.User_Aggregate;
using Common.L2.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
