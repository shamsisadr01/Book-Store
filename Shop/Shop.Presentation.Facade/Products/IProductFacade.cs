using Common.L2.Application;
using Shop.L2.Application.Products.AddImage;
using Shop.L2.Application.Products.Create;
using Shop.L2.Application.Products.Edit;
using Shop.L2.Application.Products.RemoveImage;
using Shop.L4.Query.Products.DTOs;

namespace Shop.L5.Presentation.Facade.Products
{
	public interface IProductFacade
	{
		Task<OperationResult> CreateProduct(CreateProductCommand command);
		Task<OperationResult> EditProduct(EditProductCommand command);
		Task<OperationResult> AddImage(AddProductImageCommand command);
		Task<OperationResult> RemoveImage(RemoveProductImageCommand command);

		Task<ProductDto?> GetProductById(long productId);
		Task<ProductDto?> GetProductBySlug(string slug);
		Task<ProductFilterResult> GetProductsByFilter(ProductFilterParams filterParams);
	}
}
