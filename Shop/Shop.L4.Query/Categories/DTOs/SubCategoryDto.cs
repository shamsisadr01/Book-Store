﻿using Common.L1.Domain.ValueObjects;
using Common.L4.Query;

namespace Shop.L4.Query.Categories.DTOs
{
	public class SubCategoryDto : BaseDto
	{
		public string Title { get; set; }
		public string Slug { get; set; }
		public SeoData SeoData { get; set; }
		public long ParentId { get; set; }
		public List<SecondaryCategoryDto> Childs { get; set; }
	}
}
