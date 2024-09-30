using Common.L2.Application;
using Shop.L2.Application.Categories.AddChild;
using Shop.L2.Application.Categories.Create;
using Shop.L2.Application.Categories.Edit;
using Shop.L4.Query.Categories.DTOs;

namespace Shop.L5.Presentation.Facade.Categories;

public interface ICategoryFacade
{
	Task<OperationResult> AddChild(AddChildCategoryCommand command);
	Task<OperationResult> Edit(EditCategoryCommand command);
	Task<OperationResult> Create(CreateCategroyCommand command);
	Task<OperationResult> Remove(long categoryId);


	Task<CategoryDto> GetCategoryById(long id);
	Task<List<SubCategoryDto>> GetCategoriesByParentId(long parentId);
	Task<List<CategoryDto>> GetCategories();
}