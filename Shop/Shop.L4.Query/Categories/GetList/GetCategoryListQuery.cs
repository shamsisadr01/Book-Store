﻿using Common.L4.Query;
using Shop.L4.Query.Categories.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L4.Query.Categories.GetList
{
	public record GetCategoryListQuery : IQuery<List<CategoryDto>>;
}
