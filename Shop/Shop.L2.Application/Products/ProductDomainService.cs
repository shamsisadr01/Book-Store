using Shop.L1.Domain.Product_Aggregate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.L1.Domain.Product_Aggregate.Repository;

namespace Shop.L2.Application.Products
{
	public class ProductDomainService : IProductDomainService
	{
		private readonly IProductRepository _repository;

		public ProductDomainService(IProductRepository repository)
		{
			_repository = repository;
		}

		public bool SlugIsExist(string slug)
		{
			return _repository.Exists(s => s.Slug == slug);
		}
	}
}
