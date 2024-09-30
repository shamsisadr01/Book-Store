using Common.L2.Application;
using MediatR;
using Shop.L2.Application.Products.AddImage;
using Shop.L2.Application.Products.Create;
using Shop.L2.Application.Products.Edit;
using Shop.L2.Application.Products.RemoveImage;
using Shop.L4.Query.Products.DTOs;
using Shop.L4.Query.Products.GetByFilter;
using Shop.L4.Query.Products.GetById;
using Shop.L4.Query.Products.GetBySlug;

namespace Shop.L5.Presentation.Facade.Products;

internal class ProductFacade : IProductFacade
{
	private readonly IMediator _mediator;
	public ProductFacade(IMediator mediator)
	{
		_mediator = mediator;
	}
	public async Task<OperationResult> CreateProduct(CreateProductCommand command)
	{
		return await _mediator.Send(command);
	}
	public async Task<OperationResult> EditProduct(EditProductCommand command)
	{
		return await _mediator.Send(command);
	}
	public async Task<OperationResult> AddImage(AddProductImageCommand command)
	{
		return await _mediator.Send(command); ;
	}
	public async Task<OperationResult> RemoveImage(RemoveProductImageCommand command)
	{
		return await _mediator.Send(command);
	}
	public async Task<ProductDto?> GetProductById(long productId)
	{
		return await _mediator.Send(new GetProductByIdQuery(productId));
	}
	public async Task<ProductDto?> GetProductBySlug(string slug)
	{
		return await _mediator.Send(new GetProductBySlugQuery(slug));
	}
	public async Task<ProductFilterResult> GetProductsByFilter(ProductFilterParams filterParams)
	{
		return await _mediator.Send(new GetProductsByFilterQuery(filterParams));
	}
}