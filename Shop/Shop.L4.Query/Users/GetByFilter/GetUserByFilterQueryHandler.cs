using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.Users.DTOs;

namespace Shop.L4.Query.Users.GetByFilter;

public class GetUserByFilterQueryHandler : IQueryHandler<GetUserByFilterQuery, UserFilterResult>
{
	private StoreContext _storeContext;

	public GetUserByFilterQueryHandler(StoreContext storeContext)
	{
		_storeContext = storeContext;
	}

	public async Task<UserFilterResult> Handle(GetUserByFilterQuery request, CancellationToken cancellationToken)
	{
		var @params = request.FilterParamses;
		var result = _storeContext.Users.OrderByDescending(d => d.Id).AsQueryable();

		if (!string.IsNullOrWhiteSpace(@params.Email))
			result = result.Where(r => r.Email.Contains(@params.Email));

		if (!string.IsNullOrWhiteSpace(@params.PhoneNumber))
			result = result.Where(r => r.PhoneNumber.Contains(@params.PhoneNumber));

		if (@params.Id != null)
			result = result.Where(r => r.Id == @params.Id);

		var skip = (@params.PageId - 1) * @params.Take;
		var model = new UserFilterResult()
		{
			Data = await result.Skip(skip).Take(@params.Take)
				.Select(s => s.MapFilterData())
				.ToListAsync(cancellationToken),
			FilterParams = @params
		};
		model.GeneratePaging(result, @params.Take, @params.PageId);
		return model;
	}
}