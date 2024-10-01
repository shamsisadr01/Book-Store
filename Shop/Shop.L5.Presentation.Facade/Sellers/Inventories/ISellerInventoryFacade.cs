using Common.L2.Application;
using Shop.L2.Application.Sellers.AddInventory;
using Shop.L2.Application.Sellers.EditInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.L5.Presentation.Facade.Sellers.Inventories
{
	public interface ISellerInventoryFacade
	{
		Task<OperationResult> AddInventory(AddSellerInventoryCommand command);
		Task<OperationResult> EditInventory(EditSellerInventoryCommand command);
	}
}
