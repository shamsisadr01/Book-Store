using Common.L4.Query;
using Shop.L3.Infrastructure.Persistent.Dapper;
using Shop.L4.Query.Sellers.DTOs;

namespace Shop.L4.Query.Sellers.GetByUserId;

public record GetSellerByUserIdQuery(long UserId) : IQuery<SellerDto?>;