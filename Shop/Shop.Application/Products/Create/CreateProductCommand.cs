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

		public string Title { get;private  set; }
		public IFormFile ImageFile { get;private set; }
		public string Description { get;private set; }
		public long CategoryId { get;private set; }
		public long SubCategoryId { get;private set; }
		public long SecondarySubCategoryId { get;private set; }
		public string Slug { get; private set; }
		public SeoData SeoData { get; private set; }
		public Dictionary<string, string> ProductDetails { get;private set; }
	}
}
