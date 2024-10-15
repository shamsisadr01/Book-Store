using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.SiteEntities.DTOs;

namespace Shop.L4.Query.SiteEntities.ShippingMethods.GetList;

internal class GetShippingMethodsByListQueryHandler : IQueryHandler<GetShippingMethodsByListQuery, List<ShippingMethodDto>>
{
    private readonly StoreContext _context;

    public GetShippingMethodsByListQueryHandler(StoreContext context)
    {
        _context = context;
    }

    public async Task<List<ShippingMethodDto>> Handle(GetShippingMethodsByListQuery request, CancellationToken cancellationToken)
    {
        return await _context.ShippingMethods.Select(s => new ShippingMethodDto
        {
            Id = s.Id,
            CreationDate = s.CreationDate,
            Title = s.Title,
            Cost = s.Cost
        }).ToListAsync(cancellationToken);
    }
}