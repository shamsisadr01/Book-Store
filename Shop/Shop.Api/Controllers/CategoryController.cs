﻿using System.Net;
using Common.AspNetCore;
using Common.L2.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.L2.Application.Categories.AddChild;
using Shop.L2.Application.Categories.Create;
using Shop.L2.Application.Categories.Edit;
using Shop.L2.Application.Categories.Remove;
using Shop.L4.Query.Categories.DTOs;
using Shop.L5.Presentation.Facade.Categories;

namespace Shop.Api.Controllers
{
	public class CategoryController : ApiController
	{
		private readonly ICategoryFacade _categoryFacade;

		public CategoryController(ICategoryFacade categoryFacade)
		{
			_categoryFacade = categoryFacade;
		}

		[HttpGet]
		public async Task<ApiResult<List<CategoryDto>>> GetCategories()
		{
			var result = await _categoryFacade.GetCategories();
			return QueryResult(result);
		}

		[HttpGet("{id}")]
		public async Task<ApiResult<CategoryDto>> GetCategoryById(long id)
		{
			var result = await _categoryFacade.GetCategoryById(id);
			return QueryResult(result);
		}

		[HttpGet("getChilds/{parentId}")]
		public async Task<ApiResult<List<SubCategoryDto>>> GetCategoryByParentId(long parentId)
		{
			var result = await _categoryFacade.GetCategoriesByParentId(parentId);
			return QueryResult(result);
		}

		[HttpPost]
		public async Task<ApiResult<long>> CreateCategory(CreateCategoryCommand command)
		{
			var result = await _categoryFacade.Create(command);
			var url = Url.Action("GetCategoryById", "Category", new { id = result.Data }, Request.Scheme);
			return CommandResult(result, HttpStatusCode.Created, url);
		}

		[HttpPost("AddChild")]
		public async Task<ApiResult<long>> AddSubCategory(AddChildCategoryCommand command)
		{
			var result = await _categoryFacade.AddChild(command);
			var url = Url.Action("GetCategoryById", "Category", new { id = result.Data }, Request.Scheme);
			return CommandResult(result,HttpStatusCode.Created,url);
		}

		[HttpPut]
		public async Task<ApiResult> EditCategory(EditCategoryCommand command)
		{
			var result = await _categoryFacade.Edit(command);
			return CommandResult(result);
		}

		[HttpDelete("{categoryId}")]
		public async Task<ApiResult> DeleteCategory(long categoryId)
		{
			var result = await _categoryFacade.Remove(categoryId);
			return CommandResult(result);
		}
	}
}
