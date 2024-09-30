using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.Sellers.DTOs;

namespace Shop.L4.Query.Sellers.GetByFilter;

public class GetSellerByFilterQueryHandler : IQueryHandler<GetSellerByFilterQuery, SellerFilterResult>
{
	private readonly StoreContext _storeContext;

	public GetSellerByFilterQueryHandler(StoreContext storeContext)
	{
		_storeContext = storeContext;
	}

	public async Task<SellerFilterResult> Handle(GetSellerByFilterQuery request, CancellationToken cancellationToken)
	{
		var @params = request.FilterParamses;
		var result = _storeContext.Sellers.OrderByDescending(d=>d.Id).AsQueryable();

		if (!string.IsNullOrWhiteSpace(@params.NationalCode))
			result = result.Where(s => s.NationalCode.Contains(@params.NationalCode));

		if (!string.IsNullOrWhiteSpace(@params.ShopName))
			result = result.Where(s => s.ShopName.Contains(@params.ShopName));

		var skip = (@params.PageId - 1) * @params.Take;
		var model = new SellerFilterResult()
		{
			Data = await result.Skip(skip).Take(@params.Take)
				.Select(s=>s.Map())
				.ToListAsync(cancellationToken),
			FilterParams = @params
		};
		model.GeneratePaging(result, @params.Take, @params.PageId);
		return model;
	}
}