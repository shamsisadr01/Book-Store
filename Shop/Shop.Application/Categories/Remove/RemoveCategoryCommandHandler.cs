using Common.L2.Application;
using Shop.L1.Domain.Category_Aggregate.Repository;

namespace Shop.L2.Application.Categories.Remove;

public class RemoveCategoryCommandHandler : IBaseCommandHandler<RemoveCategoryCommand>
{
	private readonly ICategoryRepository _categoryRepository;

	public RemoveCategoryCommandHandler(ICategoryRepository categoryRepository)
	{
		_categoryRepository = categoryRepository;
	}

	public async Task<OperationResult> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
	{
		var result = await _categoryRepository.DeleteCategory(request.categoryId);
		if(result)
			return OperationResult.Success();

		return OperationResult.Error("امکان حذف این دسته وجود ندارد.");
	}
}