using Common.L4.Query;
using Shop.L4.Query.Sellers.DTOs;

namespace Shop.L4.Query.Sellers.Inventories.GetByProductId;

public record GetInventoriesByProductIdQuery(long ProductId) : IQuery<List<InventoryDto>>;