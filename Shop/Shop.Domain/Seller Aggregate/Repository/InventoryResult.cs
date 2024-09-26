namespace Shop.L1.Domain.Seller_Aggregate.Repository
{
	public class InventoryResult
	{
		public long Id { get; set; }
		public long SellerId { get; set; }
		public long ProductId { get; set; }
		public int Count { get; set; }
		public int Price { get; set; }
	}
}
