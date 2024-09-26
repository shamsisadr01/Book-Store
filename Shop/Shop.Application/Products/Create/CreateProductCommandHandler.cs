using Common.L2.Application;
using Common.L2.Application.FileUtil.Interfaces;
using Shop.L1.Domain.Product_Aggregate;
using Shop.L1.Domain.Product_Aggregate.Repository;
using Shop.L1.Domain.Product_Aggregate.Services;
using Shop.L2.Application._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Products.Create
{
	public class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
	{
		private readonly IProductDomainService _domainService;
		private readonly IProductRepository _repository;
		private readonly IFileService _fileService;

		public CreateProductCommandHandler(IProductDomainService domainService, IProductRepository repository, IFileService fileService)
		{
			_domainService = domainService;
			_repository = repository;
			_fileService = fileService;
		}

		public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
		{
			var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImages);
			var product = new Product(request.Title, imageName, request.Description, request.CategoryId,
			   request.SubCategoryId, request.SecondarySubCategoryId, request.Slug,
			   request.SeoData, _domainService);

			await _repository.Add(product);

			var productDetails = new List<ProductDetail>();
			request.ProductDetails.ToList().ForEach(detail =>
			{
				productDetails.Add(new ProductDetail(detail.Key, detail.Value));
			});

			product.SetDetail(productDetails);
			await _repository.Save();
			return OperationResult.Success();

		}
	}
}
