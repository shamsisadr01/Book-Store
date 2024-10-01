using Common.L2.Application;
using MediatR;
using Shop.L2.Application.Sellers.AddInventory;
using Shop.L2.Application.Sellers.EditInventory;

namespace Shop.L5.Presentation.Facade.Sellers.Inventories;

internal class SellerInventoryFacade : ISellerInventoryFacade
{
	private IMediator _mediator;
	public SellerInventoryFacade(IMediator mediator)
	{
		_mediator = mediator;
	}
	public async Task<OperationResult> AddInventory(AddSellerInventoryCommand command)
	{
		return await _mediator.Send(command);
	}
	public async Task<OperationResult> EditInventory(EditSellerInventoryCommand command)
	{
		return await _mediator.Send(command);
	}
}