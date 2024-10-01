using Common.L2.Application;
using Common.L2.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.L1.Domain.Product_Aggregate;
using Shop.L1.Domain.Product_Aggregate.Repository;
using Shop.L1.Domain.Product_Aggregate.Services;
using Shop.L2.Application._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Products.Edit
{
	public class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
	{
		private readonly IProductDomainService _domainService;
		private readonly IProductRepository _repository;
		private readonly IFileService _fileService;

		public EditProductCommandHandler(IProductDomainService domainService, IProductRepository repository, IFileService fileService)
		{
			_domainService = domainService;
			_repository = repository;
			_fileService = fileService;
		}

		public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
		{
			var product = await _repository.GetTracking(request.ProductId);
			if (product == null)
				return OperationResult.NotFound();

			product.Edit(request.Title, request.Description, request.CategoryId, request.SubCategoryId,
				request.SecondarySubCategoryId, request.Slug, request.SeoData, _domainService);

			var oldImage = product.ImageName;

			if (request.ImageFile != null)
			{
				var imageName = await _fileService
					.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);
				product.SetProductImage(imageName);
			}
			var productDetails = new List<ProductDetail>();
			request.Specifications.ToList().ForEach(detail =>
			{
				productDetails.Add(new ProductDetail(detail.Key, detail.Value));
			});
			product.SetDetail(productDetails);
			await _repository.Save();
			RemoveOldImage(request.ImageFile, oldImage);
			return OperationResult.Success();
		}
		private void RemoveOldImage(IFormFile imageFile, string oldImageName)
		{
			if (imageFile != null)
			{
				_fileService.DeleteFile(Directories.ProductImages, oldImageName);
			}
		}
	}
}
