using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.L4.Query;
using Shop.L4.Query.Users.DTOs;

namespace Shop.L4.Query.Users.UserTokens
{
	public record GetUserTokenByRefreshTokenQuery(string HashRefreshToken) : IQuery<UserTokenDto>;
}
