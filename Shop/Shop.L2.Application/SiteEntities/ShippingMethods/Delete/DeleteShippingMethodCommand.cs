using Common.L2.Application;

namespace Shop.L2.Application.SiteEntities.ShippingMethods.Delete;

public record DeleteShippingMethodCommand(long Id) : IBaseCommand;