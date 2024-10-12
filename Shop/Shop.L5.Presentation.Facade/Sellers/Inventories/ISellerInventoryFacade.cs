using Common.L2.Application;
using Shop.L2.Application.Sellers.AddInventory;
using Shop.L2.Application.Sellers.EditInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.L4.Query.Sellers.DTOs;

namespace Shop.L5.Presentation.Facade.Sellers.Inventories
{
	public interface ISellerInventoryFacade
	{
		Task<OperationResult> AddInventory(AddSellerInventoryCommand command);
		Task<OperationResult> EditInventory(EditSellerInventoryCommand command);
		Task<InventoryDto?> GetById(long inventoryId);
		Task<List<InventoryDto>> GetList(long sellerId);

        Task<List<InventoryDto>> GetByProductId(long productId);
    }
}
