
using Common.L2.Application;
using Common.L2.Application.FileUtil.Interfaces;
using Shop.L1.Domain.SiteEntities.Repositories;
using Shop.L2.Application._Utilities;

namespace Shop.L2.Application.SiteEntities.Banner.Create
{
	public class CreateBannerCommandHandler : IBaseCommandHandler<CreateBannerCommand>
	{
		private readonly IBannerRepository _repository;
		private readonly IFileService _fileService;

		public CreateBannerCommandHandler(IBannerRepository repository, IFileService fileService)
		{
			_repository = repository;
			_fileService = fileService;
		}

		public async Task<OperationResult> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
		{
			var imageName = await _fileService
				.SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);
			var banner = new L1.Domain.SiteEntities.Banner(request.Link, imageName, request.Position);

			_repository.Add(banner);
			await _repository.Save();
			return OperationResult.Success();
		}
	}
}
