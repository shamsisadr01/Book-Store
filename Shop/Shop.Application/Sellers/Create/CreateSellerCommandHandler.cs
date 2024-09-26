using Common.L2.Application;
using Shop.L1.Domain.Seller_Aggregate;
using Shop.L1.Domain.Seller_Aggregate.Repository;
using Shop.L1.Domain.Seller_Aggregate.Services;

namespace Shop.L2.Application.Sellers.Create
{
	public class CreateSellerCommandHandler : IBaseCommandHandler<CreateSellerCommand>
	{
		private readonly ISellerRepository _repository;
		private readonly ISellerDomainService _domainService;
		public CreateSellerCommandHandler(ISellerRepository repository, ISellerDomainService domainService)
		{
			_repository = repository;
			_domainService = domainService;
		}

		public async Task<OperationResult> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
		{
			var seller = new Seller(request.UserId, request.ShopName, request.NationalCode, _domainService);

			_repository.Add(seller);
			await _repository.Save();

			return OperationResult.Success();
		}
	}
}
