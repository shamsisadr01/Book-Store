using Common.L2.Application;
using MediatR;
using Shop.L2.Application.SiteEntities.ShippingMethods.Create;
using Shop.L2.Application.SiteEntities.ShippingMethods.Delete;
using Shop.L2.Application.SiteEntities.ShippingMethods.Edit;
using Shop.L4.Query.SiteEntities.DTOs;
using Shop.L4.Query.SiteEntities.ShippingMethods.GetById;
using Shop.L4.Query.SiteEntities.ShippingMethods.GetList;

namespace Shop.L5.Presentation.Facade.SiteEntities.ShippingMethods;

internal class ShippingMethodFacade : IShippingMethodFacade
{
    private readonly IMediator _mediator;

    public ShippingMethodFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Create(CreateShippingMethodCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditShippingMethodCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OperationResult> Delete(long id)
    {
        return await _mediator.Send(new DeleteShippingMethodCommand(id));

    }

    public async Task<ShippingMethodDto?> GetShippingMethodById(long id)
    {
        return await _mediator.Send(new GetShippingMethodByIdQuery(id));

    }

    public async Task<List<ShippingMethodDto>> GetList()
    {
        return await _mediator.Send(new GetShippingMethodsByListQuery());

    }
}