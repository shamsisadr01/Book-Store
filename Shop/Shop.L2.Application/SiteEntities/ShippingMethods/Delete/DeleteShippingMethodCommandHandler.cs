using Common.L2.Application;
using Shop.L1.Domain.SiteEntities.Repositories;

namespace Shop.L2.Application.SiteEntities.ShippingMethods.Delete;

internal class DeleteShippingMethodCommandHandler : IBaseCommandHandler<DeleteShippingMethodCommand>
{
    private readonly IShippingMethodRepository _repository;

    public DeleteShippingMethodCommandHandler(IShippingMethodRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(DeleteShippingMethodCommand request, CancellationToken cancellationToken)
    {
        var shipping = await _repository.GetTracking(request.Id);
        if (shipping == null)
            return OperationResult.NotFound();

        _repository.Delete(shipping);
        await _repository.Save();
        return OperationResult.Success();
    }
}