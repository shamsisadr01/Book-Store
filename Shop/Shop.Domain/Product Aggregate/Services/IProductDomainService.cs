using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shop.Domain.Product_Aggregate.Services
{
	public interface IProductDomainService
	{
		bool SlugIsExist(string slug);
	}
}
