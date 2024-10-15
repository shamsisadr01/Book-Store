using Common.L4.Query;

namespace Shop.L4.Query.SiteEntities.DTOs;

public class ShippingMethodDto : BaseDto
{
    public string Title { get; set; }
    public int Cost { get; set; }
}