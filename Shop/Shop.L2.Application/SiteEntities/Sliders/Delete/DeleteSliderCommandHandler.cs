using Common.L2.Application;
using Common.L2.Application.FileUtil.Interfaces;
using Shop.L1.Domain.SiteEntities.Repositories;
using Shop.L2.Application._Utilities;

namespace Shop.L2.Application.SiteEntities.Sliders.Delete;

internal class DeleteSliderCommandHandler : IBaseCommandHandler<DeleteSliderCommand>
{
    private readonly ISliderRepository _repository;
    private readonly IFileService _localFileService;
    public DeleteSliderCommandHandler(ISliderRepository repository, IFileService localFileService)
    {
        _repository = repository;
        _localFileService = localFileService;
    }

    public async Task<OperationResult> Handle(DeleteSliderCommand request, CancellationToken cancellationToken)
    {
        var slider = await _repository.GetTracking(request.Id);
        if (slider == null) return OperationResult.NotFound();

        _repository.Delete(slider);
        await _repository.Save();
        _localFileService.DeleteFile(Directories.SliderImages, slider.ImageName);
        return OperationResult.Success();
    }
}