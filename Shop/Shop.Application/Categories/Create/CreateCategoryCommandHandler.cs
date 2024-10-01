using Common.L2.Application;
using MediatR;
using Shop.L1.Domain.Category_Aggregate;
using Shop.L1.Domain.Category_Aggregate.Repository;
using Shop.L1.Domain.Category_Aggregate.Services;

namespace Shop.L2.Application.Categories.Create
{
	public class CreateCategoryCommandHandler : IBaseCommandHandler<CreateCategoryCommand,long>
	{
		private readonly ICategoryRepository _repository;
		private readonly ICategoryDomainService _domainService;

		public CreateCategoryCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
		{
			_repository = repository;
			_domainService = domainService;
		}

		public async Task<OperationResult<long>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
		{
			var category = new Category(request.title, request.slug, request.seoData,_domainService);
			 _repository.Add(category);
			await _repository.Save();
			return OperationResult<long>.Success(category.Id);
		}
	}
}
