using Common.L2.Application;
using Shop.L1.Domain.Category_Aggregate.Repository;
using Shop.L1.Domain.Category_Aggregate.Services;

namespace Shop.L2.Application.Categories.Edit
{
	public class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand>
	{
		private readonly ICategoryRepository _repository;
		private readonly ICategoryDomainService _domainService;

		public EditCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
		{
			_repository = repository;
			_domainService = domainService;
		}

		public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
		{
			var category = await _repository.GetTracking(request.id);
			if (category == null)
				return OperationResult.NotFound();

			category.Edit(request.title,request.slug,request.seoData,_domainService);
			await _repository.Save();
			return OperationResult.Success();
		}
	}
}
