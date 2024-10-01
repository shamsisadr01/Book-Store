using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.Users.DTOs;

namespace Shop.L4.Query.Users.GetById;

public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto?>
{
	private StoreContext _storeContext;

	public GetUserByIdQueryHandler(StoreContext storeContext)
	{
		_storeContext = storeContext;
	}

	public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
	{
		var user = await _storeContext.Users.FirstOrDefaultAsync(u => u.Id == request.userId, cancellationToken);
		if (user == null)
			return null;
		return await user.Map().SetUserRoleTitles(_storeContext);
	}
}