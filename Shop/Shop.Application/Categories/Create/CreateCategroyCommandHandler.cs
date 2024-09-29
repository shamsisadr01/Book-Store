using Common.L2.Application;
using Shop.L1.Domain.Category_Aggregate;
using Shop.L1.Domain.Category_Aggregate.Repository;
using Shop.L1.Domain.Category_Aggregate.Services;

namespace Shop.L2.Application.Categories.Create
{
	public class CreateCategroyCommandHandler : IBaseCommandHandler<CreateCategroyCommand>
	{
		private readonly ICategoryRepository _repository;
		private readonly ICategoryDomainService _domainService;

		public CreateCategroyCommandHandler(ICategoryRepository repository, ICategoryDomainService domainService)
		{
			_repository = repository;
			_domainService = domainService;
		}

		public async Task<OperationResult> Handle(CreateCategroyCommand request, CancellationToken cancellationToken)
		{
			var category = new Category(request.title, request.slug, request.seoData,_domainService);
			 _repository.Add(category);
			await _repository.Save();
			return OperationResult.Success();
		}
	}
}
