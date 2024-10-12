using Common.L2.Application;
using MediatR;
using Shop.L2.Application.Sellers.AddInventory;
using Shop.L2.Application.Sellers.EditInventory;
using Shop.L4.Query.Sellers.DTOs;
using Shop.L4.Query.Sellers.Inventories.GetById;
using Shop.L4.Query.Sellers.Inventories.GetByProductId;
using Shop.L4.Query.Sellers.Inventories.GetList;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

	public async Task<InventoryDto?> GetById(long inventoryId)
	{
		return await _mediator.Send(new GetSellerInventoryByIdQuery(inventoryId));
	}

	public async Task<List<InventoryDto>> GetList(long sellerId)
	{
		return await _mediator.Send(new GetInventoriesQuery(sellerId));
	}

    public async Task<List<InventoryDto>> GetByProductId(long productId)
    {
        return await _mediator.Send(new GetInventoriesByProductIdQuery(productId));
    }
}