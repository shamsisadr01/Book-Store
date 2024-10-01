using Common.L4.Query;
using Shop.L4.Query.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L4.Query.Products.GetBySlug
{
	public record GetProductBySlugQuery(string slug) : IQuery<ProductDto?>;
}
