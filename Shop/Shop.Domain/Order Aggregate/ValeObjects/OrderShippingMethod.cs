using Common.L1.Domain;

namespace Shop.L1.Domain.Order_Aggregate.ValeObjects
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
