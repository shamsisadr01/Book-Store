using Common.L2.Application;
using MediatR;
using Shop.L2.Application.SiteEntities.Banner.Create;
using Shop.L2.Application.SiteEntities.Banner.Edit;
using Shop.L4.Query.SiteEntities._DTOs;
using Shop.L4.Query.SiteEntities.Banners.GetById;
using Shop.L4.Query.SiteEntities.Banners.GetByList;

namespace Shop.L5.Presentation.Facade.SiteEntities.Banner;

internal class BannerFacade : IBannerFacade
{
	private readonly IMediator _mediator;
	public BannerFacade(IMediator mediator)
	{
		_mediator = mediator;
	}
	public async Task<OperationResult> CreateBanner(CreateBannerCommand command)
	{
		return await _mediator.Send(command);
	}
	public async Task<OperationResult> EditBanner(EditBannerCommand command)
	{
		return await _mediator.Send(command);
	}
	public async Task<BannerDto?> GetBannerById(long id)
	{
		return await _mediator.Send(new GetBannerByIdQuery(id));
	}
	public async Task<List<BannerDto>> GetBanners()
	{
		return await _mediator.Send(new GetBannersByListQuery());
	}
}