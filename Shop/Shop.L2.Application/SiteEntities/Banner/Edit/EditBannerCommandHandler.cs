using Common.L2.Application.FileUtil.Interfaces;
using Common.L2.Application.SecurityUtil;
using Common.L2.Application;
using Microsoft.AspNetCore.Http;
using Shop.L1.Domain.SiteEntities.Repositories;
using Shop.L2.Application._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.SiteEntities.Banner.Edit
{
	public class EditBannerCommandHandler : IBaseCommandHandler<EditBannerCommand>
	{
		private readonly IBannerRepository _repository;
		private readonly IFileService _fileService;
		public EditBannerCommandHandler(IBannerRepository repository, IFileService fileService)
		{
			_repository = repository;
			_fileService = fileService;
		}

		public async Task<OperationResult> Handle(EditBannerCommand request, CancellationToken cancellationToken)
		{
			var banner = await _repository.GetTracking(request.Id);
			if (banner == null)
				return OperationResult.NotFound();

			var imageName = banner.ImageName;
			var oldImage = banner.ImageName;

			if (request.ImageFile.IsImage())
				imageName = await _fileService
					.SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);

			banner.Edit(request.Link, imageName, request.Position);

			DeleteOldImage(request.ImageFile, oldImage);
			await _repository.Save();
			return OperationResult.Success();
		}

		private void DeleteOldImage(IFormFile? imageFile, string oldImage)
		{
			if (imageFile.IsImage())
				_fileService.DeleteFile(Directories.BannerImages, oldImage);
		}
	}
}
