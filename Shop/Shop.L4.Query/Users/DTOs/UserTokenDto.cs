using Common.L4.Query;

namespace Shop.L4.Query.Users.DTOs;

public class UserTokenDto : BaseDto
{
	public long UserId { get;  set; }
	public string HashJwToken { get;  set; }
	public string HashRefreshToken { get;  set; }

	public DateTime TokenExpireDate { get;  set; }
	public DateTime RefreshTokenExpireDate { get;  set; }
	public string Device { get; private set; }
}