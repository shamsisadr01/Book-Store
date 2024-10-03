using Common.L4.Query;
using Shop.L4.Query.Users.DTOs;

namespace Shop.L4.Query.Users.UserTokens.GetByToken;

public record GetUserTokenByJwtTokenQuery(string HashToken) : IQuery<UserTokenDto?>;