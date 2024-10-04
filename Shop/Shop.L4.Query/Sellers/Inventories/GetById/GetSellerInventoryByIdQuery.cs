using Shop.L4.Query.Sellers.DTOs;

namespace Shop.L4.Query.Sellers.Inventories.GetById;

using Common.L4.Query;

public record GetSellerInventoryByIdQuery(long InventoryId) : IQuery<InventoryDto?>;