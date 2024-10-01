using Common.L2.Application;
using Common.L2.Application.FileUtil.Interfaces;
using Shop.L1.Domain.SiteEntities;
using Shop.L1.Domain.SiteEntities.Repositories;
using Shop.L2.Application._Utilities;

namespace Shop.L2.Application.SiteEntities.Sliders.Create
{
	public class CreateSliderCommandHandler : IBaseCommandHandler<CreateSliderCommand>
	{
		private readonly IFileService _fileService;
		private readonly ISliderRepository _repository;

		public CreateSliderCommandHandler(IFileService fileService, ISliderRepository repository)
		{
			_fileService = fileService;
			_repository = repository;
		}

		public async Task<OperationResult> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
		{
			var imageName = await _fileService
				.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);
			var slider = new Slider(request.Title, request.Link, imageName);

			_repository.Add(slider);
			await _repository.Save();
			return OperationResult.Success();
		}
	}
}
