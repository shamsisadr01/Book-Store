﻿using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.L2.Application.Products.AddImage;
using Shop.L2.Application.Products.Create;
using Shop.L2.Application.Products.Edit;
using Shop.L2.Application.Products.RemoveImage;
using Shop.L4.Query.Products.DTOs;
using Shop.L5.Presentation.Facade.Products;

namespace Shop.Api.Controllers
{
	public class ProductController : ApiController
	{
		private readonly IProductFacade _productFacade;

		public ProductController(IProductFacade productFacade)
		{
			_productFacade = productFacade;
		}

		[HttpGet]
		public async Task<ApiResult<ProductFilterResult>> GetProductByFilter([FromQuery] ProductFilterParams filterParams)
		{
			var result = await _productFacade.GetProductsByFilter(filterParams);
			return QueryResult(result);
		}

		[HttpGet("{id}")]
		public async Task<ApiResult<ProductDto?>> GetProductById(long productId)
		{
			var result = await _productFacade.GetProductById(productId);
			return QueryResult(result);
		}

		[HttpGet("{slug}")]
		public async Task<ApiResult<ProductDto?>> GetProductBySlug(string slug)
		{
			var result = await _productFacade.GetProductBySlug(slug);
			return QueryResult(result);
		}

		[HttpPost]
		public async Task<ApiResult> CreateProduct([FromForm]CreateProductCommand command)
		{
			var result = await _productFacade.CreateProduct(command);
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
