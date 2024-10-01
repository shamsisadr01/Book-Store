

using Common.L1.Domain.Repository;

namespace Shop.L1.Domain.SiteEntities.Repositories
{
	public interface IBannerRepository : IBaseRepository<Banner>
	{
		void Delete(Banner banner);
	}
}
