using Common.L2.Application;
using Shop.L2.Application.SiteEntities.Sliders.Create;
using Shop.L2.Application.SiteEntities.Sliders.Edit;
using Shop.L4.Query.SiteEntities.DTOs;

namespace Shop.L5.Presentation.Facade.SiteEntities.Slider;

public interface ISliderFacade
{
	Task<OperationResult> CreateSlider(CreateSliderCommand command);
	Task<OperationResult> EditSlider(EditSliderCommand command);
    Task<OperationResult> DeleteSlider(long sliderId);
    Task<SliderDto?> GetSliderById(long id);
	Task<List<SliderDto>> GetSliders();
}