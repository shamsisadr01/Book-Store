using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.SiteEntities.DTOs;

namespace Shop.L4.Query.SiteEntities.ShippingMethods.GetById;

public class GetShippingMethodByIdQueryHandler : IQueryHandler<GetShippingMethodByIdQuery, ShippingMethodDto?>
{
    private readonly StoreContext _context;

    public GetShippingMethodByIdQueryHandler(StoreContext context)
    {
        _context = context;
    }

    public async Task<ShippingMethodDto?> Handle(GetShippingMethodByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.ShippingMethods.Select(s => new ShippingMethodDto
        {
            Id = s.Id,
            CreationDate = s.CreationDate,
            Title = s.Title,
            Cost = s.Cost
        }).FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken: cancellationToken);
    }
}