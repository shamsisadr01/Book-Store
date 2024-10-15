using Common.L2.Application;

namespace Shop.L2.Application.SiteEntities.ShippingMethods.Edit;

public class EditShippingMethodCommand : IBaseCommand
{
    public long Id { get; set; }
    public string Title { get; set; }
    public int Cost { get; set; }
}