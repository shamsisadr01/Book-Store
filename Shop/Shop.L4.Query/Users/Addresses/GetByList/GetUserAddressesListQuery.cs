using Common.L4.Query;
using Shop.L4.Query.Users.Addresses.DTOs;

namespace Shop.L4.Query.Users.Addresses.GetByList;

public record GetUserAddressesListQuery(long userId) : IQuery<List<AddressDto>>;