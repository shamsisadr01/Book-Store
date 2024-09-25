using Common.L1.Domain.ValueObjects;
using Common.L2.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L2.Application.Categories.Edit
{
	public record EditCategoryCommand(long id,string title, string slug, SeoData seoData) : IBaseCommand;
}
