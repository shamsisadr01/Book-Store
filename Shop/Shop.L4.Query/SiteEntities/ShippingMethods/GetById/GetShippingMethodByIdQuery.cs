using Common.L4.Query;
using Shop.L4.Query.SiteEntities.DTOs;

namespace Shop.L4.Query.SiteEntities.ShippingMethods.GetById;

public record GetShippingMethodByIdQuery(long Id) : IQuery<ShippingMethodDto?>;