using Common.L4.Query;
using Dapper;
using Shop.L3.Infrastructure.Persistent.Dapper;
using Shop.L4.Query.Users.Addresses.DTOs;

namespace Shop.L4.Query.Users.Addresses.GetByList;

internal class GetUserAddressesListQueryHandler : IQueryHandler<GetUserAddressesListQuery, List<AddressDto>>
{
	private readonly DapperContext _dapperContext;

	public GetUserAddressesListQueryHandler(DapperContext dapperContext)
	{
		_dapperContext = dapperContext;
	}
	public async Task<List<AddressDto>> Handle(GetUserAddressesListQuery request, CancellationToken cancellationToken)
	{
		var sql = $"Select * from {_dapperContext.UserAddresses} where UserId=@userId";
		var context = _dapperContext.CreateConnection;
		var result = await context.QueryAsync<AddressDto>(sql, new { userId = request.userId });
		return result.ToList();
	}
}