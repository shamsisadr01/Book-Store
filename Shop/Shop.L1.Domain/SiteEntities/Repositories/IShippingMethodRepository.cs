

using Common.L1.Domain.Repository;

namespace Shop.L1.Domain.SiteEntities.Repositories
{
	public interface IShippingMethodRepository : IBaseRepository<ShippingMethod>
	{
		void Delete(ShippingMethod method);
	}
}
