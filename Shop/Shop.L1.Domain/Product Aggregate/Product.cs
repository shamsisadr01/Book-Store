﻿

using Common.L1.Domain;
using Common.L1.Domain.Exceptions;
using Common.L1.Domain.Utilities;
using Common.L1.Domain.ValueObjects;
using Shop.L1.Domain.Product_Aggregate.Services;

namespace Shop.L1.Domain.Product_Aggregate
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
		public List<ProductDetail> ProductDetails { get; private set; }


		public void Edit(string title, string description,
			long categoryId, long subCategoryId, long? secondarySubCategoryId,
			string slug, SeoData seoData, IProductDomainService domainService)
		{
			Guard(title, slug, description, domainService);

			Title = title;
			Description = description;
			CategoryId = categoryId;
			SubCategoryId = subCategoryId;
			SecondarySubCategoryId = secondarySubCategoryId;
			Slug = slug.ToSlug();
			SeoData = seoData;
		}

		public void SetProductImage(string imageName)
		{
			NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
			ImageName = imageName;
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
			ProductDetails = productDetails;
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
