﻿using Common.L2.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Sellers.EditInventory
{
	public class EditSellerInventoryCommand : IBaseCommand
	{
		public EditSellerInventoryCommand(long sellerId, long inventoryId, int count, 
			int price, int? discountPercentage)
		{
			SellerId = sellerId;
			InventoryId = inventoryId;
			Count = count;
			Price = price;
			DiscountPercentage = discountPercentage;
		}
		public long SellerId { get; private set; }
		public long InventoryId { get; private set; }
		public int Count { get; private set; }
		public int Price { get; private set; }
		public int? DiscountPercentage { get; private set; }
	}
}
