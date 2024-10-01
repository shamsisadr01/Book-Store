using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.Sellers.DTOs;

namespace Shop.L4.Query.Sellers.GetById
{
	public class GetSellerByIdQueryHandler : IQueryHandler<GetSellerByIdQuery, SellerDto?>
	{
		private readonly StoreContext _storeContext;

		public GetSellerByIdQueryHandler(StoreContext storeContext)
		{
			_storeContext = storeContext;
		}

		public async Task<SellerDto?> Handle(GetSellerByIdQuery request, CancellationToken cancellationToken)
		{
			var seller = await _storeContext.Sellers.FirstOrDefaultAsync(s => s.Id == request.sellerId, cancellationToken);
			return seller.Map();
		}
	}
}
