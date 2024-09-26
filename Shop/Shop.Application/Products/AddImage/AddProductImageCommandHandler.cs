using Common.L2.Application;
using Common.L2.Application.FileUtil.Interfaces;
using Shop.L1.Domain.Product_Aggregate;
using Shop.L1.Domain.Product_Aggregate.Repository;
using Shop.L2.Application._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Products.AddImage
{
	public class AddProductImageCommandHandler : IBaseCommandHandler<AddProductImageCommand>
	{
		private readonly IProductRepository _repository;
		private readonly IFileService _fileService;

		public AddProductImageCommandHandler(IProductRepository repository, IFileService fileService)
		{
			_repository = repository;
			_fileService = fileService;
		}

		public async Task<OperationResult> Handle(AddProductImageCommand request, CancellationToken cancellationToken)
		{
			var product = await _repository.GetTracking(request.ProductId);
			if (product == null)
				return OperationResult.NotFound();

			var imageName = await _fileService
				.SaveFileAndGenerateName(request.ImageFile, Directories.ProductGalleryImage);

			var productImage = new ProductImage(imageName, request.Sequence);
			product.AddImage(productImage);
			await _repository.Save();
			return OperationResult.Success();
		}
	}
}
