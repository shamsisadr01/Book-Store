
using Common.L2.Application;

namespace Shop.L2.Application.Users.AddToken
{
	public class AddUserTokenCommand : IBaseCommand
	{
		public AddUserTokenCommand(long userId, string hashJwToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
		{
			UserId = userId;
			HashJwToken = hashJwToken;
			HashRefreshToken = hashRefreshToken;
			TokenExpireDate = tokenExpireDate;
			RefreshTokenExpireDate = refreshTokenExpireDate;
			Device = device;
		}

		public long UserId { get; }
		public string HashJwToken { get; }
		public string HashRefreshToken { get;  }

		public DateTime TokenExpireDate { get;  }
		public DateTime RefreshTokenExpireDate { get;  }

		public string Device { get;  }
	}
}
