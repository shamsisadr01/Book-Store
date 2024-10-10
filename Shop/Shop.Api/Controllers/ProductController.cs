using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Api.ViewModels.Products;
using Shop.L1.Domain.Role_Aggregate.Enums;
using Shop.L2.Application.Products.AddImage;
using Shop.L2.Application.Products.Create;
using Shop.L2.Application.Products.Edit;
using Shop.L2.Application.Products.RemoveImage;
using Shop.L4.Query.Products.DTOs;
using Shop.L5.Presentation.Facade.Products;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Shop.Api.Controllers
{
	[PermissionChecker(Permission.CRUD_Product)]
	public class ProductController : ApiController
	{
		private readonly IProductFacade _productFacade;

		public ProductController(IProductFacade productFacade)
		{
			_productFacade = productFacade;
		}

		[HttpGet,AllowAnonymous]
		public async Task<ApiResult<ProductFilterResult>> GetProductByFilter([FromQuery] ProductFilterParams filterParams)
		{
			var result = await _productFacade.GetProductsByFilter(filterParams);
			return QueryResult(result);
		}

		[HttpGet("Shop"), AllowAnonymous]
		public async Task<ApiResult<ProductShopResult>> GetProductByFilter([FromQuery] ProductShopFilterParam filterParams)
		{
			var result = await _productFacade.GetProductsForStore(filterParams);
			return QueryResult(result);
		}

		[HttpGet("{id}")]
		public async Task<ApiResult<ProductDto?>> GetProductById(long productId)
		{
			var result = await _productFacade.GetProductById(productId);
			return QueryResult(result);
		}

		[HttpGet("bySlug/{slug}"),AllowAnonymous]
		public async Task<ApiResult<ProductDto?>> GetProductBySlug(string slug)
		{
			var result = await _productFacade.GetProductBySlug(slug);
			return QueryResult(result);
		}

		[HttpPost]
		public async Task<ApiResult> CreateProduct([FromForm] CreateProductViewModel viewModel)
		{
            var result = await _productFacade.CreateProduct(new CreateProductCommand()
            {
                SeoData = viewModel.SeoData.Map(),
                CategoryId = viewModel.CategoryId,
                Description = viewModel.Description,
                ImageFile = viewModel.ImageFile,
                SecondarySubCategoryId = viewModel.SecondarySubCategoryId,
                Slug = viewModel.Slug,
                ProductDetails = viewModel.GetSpecification(),
                SubCategoryId = viewModel.SubCategoryId,
                Title = viewModel.Title
            });
			return CommandResult(result);
		}

		[HttpPut]
		public async Task<ApiResult> EditProduct([FromForm] EditProductCommand command)
		{
			var result = await _productFacade.EditProduct(command);
			return CommandResult(result);
		}

		[HttpPost("images")]
		public async Task<ApiResult> AddImageProduct([FromForm] AddProductImageCommand command)
		{
			var result = await _productFacade.AddImage(command);
			return CommandResult(result);
		}
		[HttpDelete("images")]
		public async Task<ApiResult> RemoveImageProduct(RemoveProductImageCommand command)
		{
			var result = await _productFacade.RemoveImage(command);
			return CommandResult(result);
		}
	}
}
