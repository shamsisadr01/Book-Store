using Common.L2.Application;
using Common.L2.Application.FileUtil.Interfaces;
using Shop.L1.Domain.SiteEntities.Repositories;
using Shop.L2.Application._Utilities;

namespace Shop.L4.Query.SiteEntities.Banners.Delete;

internal class DeleteBannerCommandHandler : IBaseCommandHandler<DeleteBannerCommand>
{
    private readonly IBannerRepository _repository;
    private readonly IFileService _localFileService;
    public DeleteBannerCommandHandler(IBannerRepository repository, IFileService localFileService)
    {
        _repository = repository;
        _localFileService = localFileService;
    }

    public async Task<OperationResult> Handle(DeleteBannerCommand request, CancellationToken cancellationToken)
    {
        var banner = await _repository.GetTracking(request.Id);
        if (banner == null)
            return OperationResult.NotFound();

        _repository.Delete(banner);
        await _repository.Save();
        _localFileService.DeleteFile(Directories.BannerImages, banner.ImageName);
        return OperationResult.Success();
    }
}