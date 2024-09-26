
using Common.L1.Domain;
using Common.L1.Domain.Exceptions;

namespace Shop.L1.Domain.Seller_Aggregate
{
	public class SellerInventory : BaseEntity
	{
		public SellerInventory(long productId, int count, int price, int? discountPercentage)
		{
			if (price < 1 || count < 0)
				throw new InvalidDomainDataException();

			ProductId = productId;
			Count = count;
			Price = price;
			DiscountPercentage = discountPercentage;
		}

		public long SellerId { get; internal set; }
		public long ProductId { get; private set; }
		public int Count { get; private set; }
		public int Price { get; private set; }
		public int? DiscountPercentage { get; private set; }


		public void Edit(int count, int price, int? discountPercentage = null)
		{
			if (price < 1 || count < 0)
				throw new InvalidDomainDataException();

			Count = count;
			Price = price;
			DiscountPercentage = discountPercentage;
		}
	}
}
