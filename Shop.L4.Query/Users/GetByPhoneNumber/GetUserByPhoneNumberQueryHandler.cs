using Common.L4.Query;
using Microsoft.EntityFrameworkCore;
using Shop.L3.Infrastructure.Persistent.Ef;
using Shop.L4.Query.Users.DTOs;

namespace Shop.L4.Query.Users.GetByPhoneNumber;

public class GetUserByPhoneNumberQueryHandler : IQueryHandler<GetUserByPhoneNumberQuery, UserDto?>
{
	private StoreContext _storeContext;

	public GetUserByPhoneNumberQueryHandler(StoreContext storeContext)
	{
		_storeContext = storeContext;
	}


	public async Task<UserDto> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
	{
		var user = await _storeContext.Users.FirstOrDefaultAsync(u => u.PhoneNumber == request.phoneNumber, cancellationToken);
		if (user == null)
			return null;
		return await user.Map().SetUserRoleTitles(_storeContext);
	}
}