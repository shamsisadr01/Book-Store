﻿using _1.Shop.Domain.Order_Aggregate.Enums;
using _1.Shop.Domain.Order_Aggregate.ValeObjects;
using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shop.Domain.Order_Aggregate
{
	public class Order : AggregateRoot
	{
		public long UserId { get;private set; }

		private Order()
		{

		}

		public Order(long userId)
		{
			UserId = userId;
			Status = OrderStatus.Pending;
			Items = new List<OrderItem>();
		}

		public OrderStatus Status { get; private set; }
		public OrderDiscount? Discount { get; private set; }
		public OrderAddress? Address { get; private set; }
		public OrderShippingMethod? ShippingMethod { get; private set; }
		public List<OrderItem> Items { get; private set; }
		public DateTime? LastUpdate { get; set; }
		public int ItemCount => Items.Count;

		public int TotalPrice
		{
			get
			{
				var totalPrice = Items.Sum(f => f.TotalPrice);
				if (ShippingMethod != null)
					totalPrice += ShippingMethod.ShippingCost;

				if (Discount != null)
					totalPrice -= Discount.DiscountAmount;

				return totalPrice;
			}
		}

		public void AddItem(OrderItem item)
		{
			ChangeOrderGuard();

			var oldItem = Items.FirstOrDefault(f => f.InventoryId == item.InventoryId);
			if (oldItem != null)
			{
				oldItem.ChangeCount(item.Count + oldItem.Count);
				return;
			}
			Items.Add(item);
		}
		public void RemoveItem(long itemId)
		{
			ChangeOrderGuard();

			var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
			if (currentItem != null)
				Items.Remove(currentItem);
		}

		public void ChangeCountItem(long itemId, int newCount)
		{
			ChangeOrderGuard();

			var currentItem = Items.FirstOrDefault(f => f.Id == itemId);
			if (currentItem == null)
				throw new NullOrEmptyDomainDataException();

			currentItem.ChangeCount(newCount);
		}
		public void ChangeStatus(OrderStatus status)
		{
			Status = status;
			LastUpdate = DateTime.Now;
		}

		public void Checkout(OrderAddress orderAddress, OrderShippingMethod shippingMethod)
		{
			ChangeOrderGuard();

			Address = orderAddress;
			ShippingMethod = shippingMethod;
		}

		public void ChangeOrderGuard()
		{
			if (Status != OrderStatus.Pending)
				throw new InvalidDomainDataException("امکان ویرایش این سفارش وجود ندارد");
		}
	}
}
