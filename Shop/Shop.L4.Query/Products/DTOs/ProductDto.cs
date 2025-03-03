﻿using Common.L1.Domain.ValueObjects;
using Common.L4.Query;
using Shop.L1.Domain.Product_Aggregate;
using Shop.L4.Query.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L4.Query.Products.DTOs
{
	public class ProductDto : BaseDto
	{
		public string Title { get;  set; }
		public string ImageName { get;  set; }
		public string Description { get;  set; }
		public ProductCategoryDto Category { get;  set; }
		public ProductCategoryDto SubCategory { get;  set; }
		public ProductCategoryDto? SecondarySubCategory { get;  set; }
		public string Slug { get;  set; }
		public SeoData SeoData { get;  set; }
		public List<ProductImageDto> Images { get;  set; }
		public List<ProductDetailDto> ProductDetails { get;  set; }
	}

	public class ProductCategoryDto
	{
		public long Id { get; set; }
		public long? ParentId { get; set; }
		public string Title { get; set; }
		public string Slug { get; set; }
		public SeoData SeoData { get; set; }
	}
}
