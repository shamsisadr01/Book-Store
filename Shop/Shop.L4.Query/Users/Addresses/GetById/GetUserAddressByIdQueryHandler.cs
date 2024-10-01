using Common.L4.Query;
using Dapper;
using Shop.L3.Infrastructure.Persistent.Dapper;
using Shop.L4.Query.Users.Addresses.DTOs;

namespace Shop.L4.Query.Users.Addresses.GetById;

public class GetUserAddressByIdQueryHandler : IQueryHandler<GetUserAddressByIdQuery, AddressDto?>
{
	private readonly DapperContext _dapperContext;

	public GetUserAddressByIdQueryHandler(DapperContext dapperContext)
	{
		_dapperContext = dapperContext;
	}

	public async Task<AddressDto?> Handle(GetUserAddressByIdQuery request, CancellationToken cancellationToken)
	{
		var sql = $"Select Top 1 * from {_dapperContext.UserAddresses} where id=@id";
		var context = _dapperContext.CreateConnection;
		var result = await context.QueryFirstAsync<AddressDto>(sql, new { id = request.addressId });
		return result;
	}
}