using Common.L4.Query;
using Shop.L4.Query.Categories.DTOs;

namespace Shop.L4.Query.Categories.GetByParentId
{
	public record GetCategoryByParentIdQuery(long ParentId) : IQuery<List<SubCategoryDto>>;
}
