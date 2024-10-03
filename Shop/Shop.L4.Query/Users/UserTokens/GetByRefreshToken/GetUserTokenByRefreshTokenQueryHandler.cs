using Common.L4.Query;
using Dapper;
using Shop.L3.Infrastructure.Persistent.Dapper;
using Shop.L4.Query.Users.DTOs;

namespace Shop.L4.Query.Users.UserTokens.GetByRefreshToken;

public class GetUserTokenByRefreshTokenQueryHandler : IQueryHandler<GetUserTokenByRefreshTokenQuery, UserTokenDto>
{
    private DapperContext _dapperContext;

    public GetUserTokenByRefreshTokenQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<UserTokenDto> Handle(GetUserTokenByRefreshTokenQuery request, CancellationToken cancellationToken)
    {
        using var connection = _dapperContext.CreateConnection;
        var sql = $"Select Top(1) * From {_dapperContext.UserTokens} Where HashRefreshToken=@hashRefreshToken";
        return await connection.QueryFirstAsync<UserTokenDto>(sql, new { hashRefreshToken = request.HashRefreshToken });
    }
}