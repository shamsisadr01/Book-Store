using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.L5.Presentation.Facade.Sellers.Inventories;
using Shop.L5.Presentation.Facade.Sellers;
using Shop.L2.Application.Sellers.AddInventory;
using Shop.L2.Application.Sellers.Create;
using Shop.L2.Application.Sellers.Edit;
using Shop.L2.Application.Sellers.EditInventory;
using Shop.L4.Query.Sellers.DTOs;

namespace Shop.Api.Controllers
{
	public class SellerController : ApiController
	{
		private readonly ISellerFacade _sellerFacade;
		private readonly ISellerInventoryFacade _sellerInventoryFacade;
		public SellerController(ISellerFacade sellerFacade, ISellerInventoryFacade sellerInventoryFacade)
		{
			_sellerFacade = sellerFacade;
			_sellerInventoryFacade = sellerInventoryFacade;
		}

		[HttpGet]
		public async Task<ApiResult<SellerFilterResult>> GetSellers(SellerFilterParams filterParams)
		{
			var result = await _sellerFacade.GetSellersByFilter(filterParams);
			return QueryResult(result);
		}

		[HttpGet("{id}")]
		public async Task<ApiResult<SellerDto?>> GetSellerById(long sellerId)
		{
			var result = await _sellerFacade.GetSellerById(sellerId);
			return QueryResult(result);
		}

		[HttpPost]
		public async Task<ApiResult> CreateSeller(CreateSellerCommand command)
		{
			var result = await _sellerFacade.CreateSeller(command);
			return CommandResult(result);
		}

		[HttpPut]
		public async Task<ApiResult> EditSeller(EditSellerCommand command)
		{
			var result = await _sellerFacade.EditSeller(command);
			return CommandResult(result);
		}

		[HttpPost("Inventory")]
		public async Task<ApiResult> AddInventory(AddSellerInventoryCommand command)
		{
			var result = await _sellerInventoryFacade.AddInventory(command);
			return CommandResult(result);
		}

		[HttpPut("Inventory")]
		public async Task<ApiResult> EditInventory(EditSellerInventoryCommand command)
		{
			var result = await _sellerInventoryFacade.EditInventory(command);
			return CommandResult(result);
		}
	}
}
