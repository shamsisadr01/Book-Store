using Shop.L1.Domain.Category_Aggregate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.L1.Domain.Category_Aggregate.Repository;

namespace Shop.L2.Application.Categories
{
	public class CategoryDomainService : ICategoryDomainService
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoryDomainService(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public bool IsSlugExist(string slug)
		{
			return _categoryRepository.Exists(s => s.Slug == slug);
		}
	}
}
