using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.Sellers.DTOs;

namespace Shop.L4.Query.Sellers.GetByUserId;

public class GetSellerByUserIdQueryHandler : IQueryHandler<GetSellerByUserIdQuery, SellerDto?>
{
	private StoreContext _context;

	public GetSellerByUserIdQueryHandler(StoreContext context)
	{
		_context = context;
	}

	public async Task<SellerDto?> Handle(GetSellerByUserIdQuery request, CancellationToken cancellationToken)
	{
		var seller = await _context.Sellers.FirstOrDefaultAsync(f => f.UserId == request.UserId,
			cancellationToken: cancellationToken);
		return seller.Map();
	}
}