using Common.L4.Query;
using Dapper;
using Shop.L3.Infrastructure.Persistent.Dapper;
using Shop.L4.Query.Users.DTOs;

namespace Shop.L4.Query.Users.UserTokens.GetByToken;

public class GetUserTokenByJwtTokenQueryHandler : IQueryHandler<GetUserTokenByJwtTokenQuery, UserTokenDto?>
{
	private DapperContext _dapperContext;

	public GetUserTokenByJwtTokenQueryHandler(DapperContext dapperContext)
	{
		_dapperContext = dapperContext;
	}
	public async Task<UserTokenDto?> Handle(GetUserTokenByJwtTokenQuery request, CancellationToken cancellationToken)
	{
		using var connection = _dapperContext.CreateConnection;
		var sql = $"Select Top(1) * From {_dapperContext.UserTokens} Where HashJwToken=@hashToken";
		return await connection.QueryFirstAsync<UserTokenDto>(sql, new { hashToken = request.HashToken });
	}
}