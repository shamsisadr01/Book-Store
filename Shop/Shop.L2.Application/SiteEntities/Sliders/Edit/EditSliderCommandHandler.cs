using Common.L2.Application.FileUtil.Interfaces;
using Common.L2.Application;
using Microsoft.AspNetCore.Http;
using Shop.L1.Domain.SiteEntities.Repositories;
using Shop.L2.Application._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.SiteEntities.Sliders.Edit
{
	internal class EditSliderCommandHandler : IBaseCommandHandler<EditSliderCommand>
	{
		private readonly IFileService _fileService;
		private readonly ISliderRepository _repository;

		public EditSliderCommandHandler(IFileService fileService, ISliderRepository repository)
		{
			_fileService = fileService;
			_repository = repository;
		}
		public async Task<OperationResult> Handle(EditSliderCommand request, CancellationToken cancellationToken)
		{
			var slider = await _repository.GetTracking(request.Id);
			if (slider == null)
				return OperationResult.NotFound();
			var imageName = slider.ImageName;
			var oldImage = slider.ImageName;
			if (request.ImageFile != null)
				imageName = await _fileService
					.SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);

			slider.Edit(request.Title, request.Link, imageName);

			await _repository.Save();
			DeleteOldImage(request.ImageFile, oldImage);
			return OperationResult.Success();
		}

		private void DeleteOldImage(IFormFile? imageFile, string oldImage)
		{
			if (imageFile != null)
				_fileService.DeleteFile(Directories.SliderImages, oldImage);
		}
	}
}
