
using Common.L1.Domain;
using Common.L1.Domain.Exceptions;

namespace Shop.L1.Domain.User_Aggregate
{
    public class UserToken : BaseEntity
    {
	    private UserToken()
	    {

	    }
	    public UserToken( string hashJwToken, string hashRefreshToken,
		    DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
	    {
			HashJwToken = hashJwToken;
		    HashRefreshToken = hashRefreshToken;
		    TokenExpireDate = tokenExpireDate;
		    RefreshTokenExpireDate = refreshTokenExpireDate;
		    Device = device;
		    Guard();
		}

	    public long UserId { get; internal set; }
        public string HashJwToken { get; private set; }
        public string HashRefreshToken { get; private set; }

        public DateTime TokenExpireDate { get; private set; }
        public DateTime RefreshTokenExpireDate { get; private set; }

        public string Device { get; private set; }

        public void Guard()
        {
            NullOrEmptyDomainDataException.CheckString(HashJwToken,nameof(HashJwToken));
            NullOrEmptyDomainDataException.CheckString(HashRefreshToken,nameof(HashRefreshToken));

            if (TokenExpireDate < DateTime.Now)
	            throw new InvalidDomainDataException("تاریخ انقضای توکن نا معتبر است.");


            if (RefreshTokenExpireDate < TokenExpireDate)
	            throw new InvalidDomainDataException("تاریخ انقضای روفرش توکن نا معتبر است.");
		}
    }
}
