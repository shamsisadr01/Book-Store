using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shop.Domain.Order_Aggregate.ValeObjects
{
	public class OrderShippingMethod : ValueObject
	{
		public OrderShippingMethod(string shippingType, int shippingCost)
		{
			ShippingType = shippingType;
			ShippingCost = shippingCost;
		}

		public string ShippingType { get; private set; }
		public int ShippingCost { get; private set; }
	}
}
