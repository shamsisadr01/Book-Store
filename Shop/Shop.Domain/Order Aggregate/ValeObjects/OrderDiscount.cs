

using Common.L1.Domain;

namespace Shop.L1.Domain.Order_Aggregate.ValeObjects
{
	public class OrderDiscount : ValueObject
	{
		public OrderDiscount(string discountTitle, int discountAmount)
		{
			DiscountTitle = discountTitle;
			DiscountAmount = discountAmount;
		}

		public string DiscountTitle { get; private set; }
		public int DiscountAmount { get; private set; }
	}
}
