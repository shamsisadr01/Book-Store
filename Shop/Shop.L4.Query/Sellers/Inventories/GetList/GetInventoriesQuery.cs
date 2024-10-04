using Common.L4.Query;
using Shop.L4.Query.Sellers.DTOs;

namespace Shop.L4.Query.Sellers.Inventories.GetList;

public record GetInventoriesQuery(long SellerId) : IQuery<List<InventoryDto>>;