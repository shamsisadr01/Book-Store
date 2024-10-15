using Common.L2.Application;

namespace Shop.L2.Application.SiteEntities.ShippingMethods.Create;

public record CreateShippingMethodCommand(int cost, string title):IBaseCommand;