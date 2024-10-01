using Common.L2.Application;
using Shop.L2.Application.SiteEntities.Banner.Create;
using Shop.L2.Application.SiteEntities.Banner.Edit;
using Shop.L4.Query.SiteEntities.DTOs;

namespace Shop.L5.Presentation.Facade.SiteEntities.Banner;

public interface IBannerFacade
{
	Task<OperationResult> CreateBanner(CreateBannerCommand command);
	Task<OperationResult> EditBanner(EditBannerCommand command);
	Task<BannerDto?> GetBannerById(long id);
	Task<List<BannerDto>> GetBanners();
}