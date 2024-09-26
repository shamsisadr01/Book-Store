using Common.L1.Domain.ValueObjects;
using Common.L2.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Products.Create
{
	public class CreateProductCommand : IBaseCommand
	{
		public CreateProductCommand(string title, IFormFile imageFile,
			string description, long categoryId, long subCategoryId, 
			long secondarySubCategoryId, 
			string slug, SeoData seoData, Dictionary<string, string> details)
		{
			Title = title;
			ImageFile = imageFile;
			Description = description;
			CategoryId = categoryId;
			SubCategoryId = subCategoryId;
			SecondarySubCategoryId = secondarySubCategoryId;
			Slug = slug;
			SeoData = seoData;
			ProductDetails = details;
		}

		public string Title { get;  set; }
		public IFormFile ImageFile { get; set; }
		public string Description { get; set; }
		public long CategoryId { get; set; }
		public long SubCategoryId { get; set; }
		public long SecondarySubCategoryId { get; set; }
		public string Slug { get; set; }
		public SeoData SeoData { get; set; }
		public Dictionary<string, string> ProductDetails { get; set; }
	}
}
