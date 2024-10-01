
using Common.L1.Domain.Repository;

namespace Shop.L1.Domain.SiteEntities.Repositories
{
	public interface ISliderRepository : IBaseRepository<Slider>
	{
		void Delete(Slider slider);
	}
}
