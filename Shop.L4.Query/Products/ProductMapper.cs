﻿using Microsoft.EntityFrameworkCore;
using Shop.L1.Domain.Product_Aggregate;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.Products.DTOs;


namespace Shop.L4.Query.Products
{
	public static class ProductMapper
	{
		public static ProductDto? Map(this Product? product)
		{
			if (product == null)
				return null;
			return new()
			{
				Id = product.Id,
				CreationDate = product.CreationDate,
				Description = product.Description,
				ImageName = product.ImageName,
				Slug = product.Slug,
				Title = product.Title,
				SeoData = product.SeoData,
				ProductDetails = product.ProductDetails.Select(s => new ProductDetailDto()
				{
					Value = s.Value,
					Key = s.Key
				}).ToList(),
				Images = product.Images.Select(s => new ProductImageDto()
				{
					Id = s.Id,
					CreationDate = s.CreationDate,
					ImageName = s.ImageName,
					ProductId = s.ProductId,
					Sequence = s.Sequence
				}).ToList(),
				Category = new()
				{
					Id = product.CategoryId
				},
				SubCategory = new()
				{
					Id = product.SubCategoryId
				},
				SecondarySubCategory = product.SecondarySubCategoryId != null ? new()
				{
					Id = (long)product.SecondarySubCategoryId
				} : null
			};
		}

		public static ProductFilterData MapListData(this Product product)
		{
			return new ProductFilterData()
			{
				Id = product.Id,
				CreationDate = product.CreationDate,
				ImageName = product.ImageName,
				Slug = product.Slug,
				Title = product.Title
			};
		}

		public static async Task SetCategories(this ProductDto product, StoreContext context)
		{
			var categories = await context.Categories
				.Where(r => r.Id == product.Category.Id || r.Id == product.SubCategory.Id)
				.Select(s => new ProductCategoryDto()
				{
					Id = s.Id,
					Slug = s.Slug,
					ParentId = s.ParentId,
					SeoData = s.SeoData,
					Title = s.Title
				}).ToListAsync();

			if (product.SecondarySubCategory != null)
			{
				var secondarySubCategory = await context.Categories
					.Where(f => f.Id == product.SecondarySubCategory.Id)
					.Select(s => new ProductCategoryDto()
					{
						Id = s.Id,
						Slug = s.Slug,
						ParentId = s.ParentId,
						SeoData = s.SeoData,
						Title = s.Title
					})
					.FirstOrDefaultAsync();

				if (secondarySubCategory != null)
					product.SecondarySubCategory = secondarySubCategory;
			}
			product.Category = categories.First(r => r.Id == product.Category.Id);
			product.SubCategory = categories.First(r => r.Id == product.SubCategory.Id);
		}
	}
}
