using Common.L2.Application;
using Shop.L1.Domain.SiteEntities;
using Shop.L1.Domain.SiteEntities.Repositories;

namespace Shop.L2.Application.SiteEntities.ShippingMethods.Create;

internal class CreateShippingMethodCommandHandler : IBaseCommandHandler<CreateShippingMethodCommand>
{
    private readonly IShippingMethodRepository _repository;

    public CreateShippingMethodCommandHandler(IShippingMethodRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CreateShippingMethodCommand request, CancellationToken cancellationToken)
    {
        _repository.Add(new ShippingMethod(request.cost, request.title));
        await _repository.Save();
        return OperationResult.Success();
    }
}