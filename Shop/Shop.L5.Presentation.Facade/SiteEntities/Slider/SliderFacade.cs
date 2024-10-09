using Common.L2.Application;
using MediatR;
using Shop.L2.Application.SiteEntities.Sliders.Create;
using Shop.L2.Application.SiteEntities.Sliders.Delete;
using Shop.L2.Application.SiteEntities.Sliders.Edit;
using Shop.L4.Query.SiteEntities.DTOs;
using Shop.L4.Query.SiteEntities.Sliders.GetById;
using Shop.L4.Query.SiteEntities.Sliders.GetByList;

namespace Shop.L5.Presentation.Facade.SiteEntities.Slider;

internal class SliderFacade : ISliderFacade
{
	private readonly IMediator _mediator;
	public SliderFacade(IMediator mediator)
	{
		_mediator = mediator;
	}
	public async Task<OperationResult> CreateSlider(CreateSliderCommand command)
	{
		return await _mediator.Send(command);
	}
	public async Task<OperationResult> EditSlider(EditSliderCommand command)
	{
		return await _mediator.Send(command);
	}

    public async Task<OperationResult> DeleteSlider(long sliderId)
    {
        return await _mediator.Send(new DeleteSliderCommand(sliderId));
    }

    public async Task<SliderDto?> GetSliderById(long id)
	{
		return await _mediator.Send(new GetSliderByIdQuery(id));
	}
	public async Task<List<SliderDto>> GetSliders()
	{
		return await _mediator.Send(new GetSlidersByListQuery());
	}
}