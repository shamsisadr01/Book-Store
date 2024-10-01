using Shop.L1.Domain.Seller_Aggregate;
using Shop.L4.Query.Sellers.DTOs;


namespace Shop.L4.Query.Sellers
{
	public static class SellerMapper
	{
		public static SellerDto Map(this Seller seller)
		{
			if (seller == null)
				return null;

			return new SellerDto()
			{
				Id = seller.Id,
				CreationDate = seller.CreationDate,
				NationalCode = seller.NationalCode,
				ShopName = seller.ShopName,
				Status = seller.Status,
				UserId = seller.UserId
			};
		}
	}
}
