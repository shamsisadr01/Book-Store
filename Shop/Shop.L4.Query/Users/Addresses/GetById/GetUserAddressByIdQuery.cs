using Common.L4.Query;
using Shop.L1.Domain.User_Aggregate.Repository;
using Shop.L4.Query.Users.Addresses.DTOs;

namespace Shop.L4.Query.Users.Addresses.GetById;

public record GetUserAddressByIdQuery(long addressId) : IQuery<AddressDto?>;