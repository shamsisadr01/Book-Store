

using Common.L1.Domain.Repository;

namespace Shop.L1.Domain.Seller_Aggregate.Repository
{
	public interface ISellerRepository : IBaseRepository<Seller>
	{
		Task<InventoryResult?> GetInventoryById(long id);
	}
}
