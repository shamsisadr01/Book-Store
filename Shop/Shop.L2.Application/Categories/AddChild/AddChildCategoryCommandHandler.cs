using Common.L2.Application;
using Shop.L1.Domain.Category_Aggregate.Repository;
using Shop.L1.Domain.Category_Aggregate.Services;

namespace Shop.L2.Application.Categories.AddChild
{
	public class AddChildCategoryCommandHandler : IBaseCommandHandler<AddChildCategoryCommand,long>
	{
		private readonly ICategoryRepository _repository;
		private readonly ICategoryDomainService _domainService;

		public AddChildCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
		{
			_repository = repository;
			_domainService = domainService;
		}
		public async Task<OperationResult<long>> Handle(AddChildCategoryCommand request, CancellationToken cancellationToken)
		{
			var category = await _repository.GetTracking(request.parentId);
			if (category == null)
				return OperationResult<long>.NotFound();

			category.AddChild(request.title, request.slug, request.seoData, _domainService);
			await _repository.Save();
			return OperationResult<long>.Success(category.Id);
		}
	}
}
