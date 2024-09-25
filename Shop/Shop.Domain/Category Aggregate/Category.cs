using Common.L1.Domain;
using Common.L1.Domain.Exceptions;
using Common.L1.Domain.Utilities;
using Common.L1.Domain.ValueObjects;
using Shop.L1.Domain.Category_Aggregate.Services;

namespace Shop.L1.Domain.Category_Aggregate
{
	public class Category : AggregateRoot
	{
		public Category(string title, string slug, SeoData seoData, ICategoryDomainService service)
		{
			slug = slug?.ToSlug();
			Guard(title, slug, service);

			Title = title;
			Slug = slug;
			SeoData = seoData;
		}

		public string Title { get; private set; }
		public string Slug { get; private set; }
		public SeoData SeoData { get; private set; }
		public long? ParentId { get; private set; }
		public List<Category> Childs { get; private set; }


		public void Edit(string title, string slug, SeoData seoData, ICategoryDomainService service)
		{
			slug = slug?.ToSlug();
			Guard(title, slug, service);
			Title = title;
			Slug = slug;
			SeoData = seoData;
		}

		public void AddChild(string title, string slug, SeoData seoData, ICategoryDomainService service)
		{
			Childs.Add(new Category(title, slug, seoData, service)
			{
				ParentId = Id
			});
		}

		public void Guard(string title, string slug, ICategoryDomainService service)
		{
			NullOrEmptyDomainDataException.CheckString(title, nameof(title));
			NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));

			if (slug != Slug)
				if (service.IsSlugExist(slug))
					throw new SlugIsDuplicateException();
		}
	}
}
