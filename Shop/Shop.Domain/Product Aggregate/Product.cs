﻿using _1.Shop.Domain.Product_Aggregate.Services;
using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using Common.Domain.Utilities;

namespace _1.Shop.Domain.Product_Aggregate
{
	public class Product : AggregateRoot
	{
		private Product()
		{

		}
		public Product(string title, string imageName, string description, 
			long categoryId, long subCategoryId, long? secondarySubCategoryId,
			string slug, SeoData seoData,IProductDomainService domainService)
		{
			NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
			Guard(title, slug, description, domainService);

			Title = title;
			ImageName = imageName;
			Description = description;
			CategoryId = categoryId;
			SubCategoryId = subCategoryId;
			SecondarySubCategoryId = secondarySubCategoryId;
			Slug = slug;
			SeoData = seoData;
		}

		public string Title { get; private set; }
		public string ImageName { get; private set; }
		public string Description { get; private set; }
		public long CategoryId { get; private set; }
		public long SubCategoryId { get; private set; }
		public long? SecondarySubCategoryId { get; private set; }
		public string Slug { get; private set; }
		public SeoData SeoData { get; private set; }
		public List<ProductImage> Images { get; private set; }
		public List<ProductDetail> productDetails { get; private set; }


		public void Edit(string title, string imageName, string description,
			long categoryId, long subCategoryId, long? secondarySubCategoryId,
			string slug, SeoData seoData, IProductDomainService domainService)
		{
			NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
			Guard(title, slug, description, domainService);

			Title = title;
			ImageName = imageName;
			Description = description;
			CategoryId = categoryId;
			SubCategoryId = subCategoryId;
			SecondarySubCategoryId = secondarySubCategoryId;
			Slug = slug.ToSlug();
			SeoData = seoData;
		}

		public void AddImage(ProductImage image)
		{
			image.ProductId = Id;
			Images.Add(image);
		}

		public string RemoveImage(long id)
		{
			var image = Images.FirstOrDefault(f => f.Id == id);
			if (image == null)
				throw new NullOrEmptyDomainDataException("عکس یافت نشد");

			Images.Remove(image);
			return image.ImageName;
		}

		public void SetDetail(List<ProductDetail> productDetails)
		{
			productDetails.ForEach(s => s.ProductId = Id);
			productDetails = productDetails;
		}

		private void Guard(string title, string slug, string description,
	   IProductDomainService domainService)
		{
			NullOrEmptyDomainDataException.CheckString(title, nameof(title));
			NullOrEmptyDomainDataException.CheckString(description, nameof(description));
			NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));

			if (slug != Slug)
				if (domainService.SlugIsExist(slug.ToSlug()))
					throw new SlugIsDuplicateException();
		}
	}
}
