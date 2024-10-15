using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Common.AspNetCore
{
    public static class ClaimUtils
    {
	    public static long GetUserId(this ClaimsPrincipal principal)
	    {
		    if (principal == null)
			    throw new ArgumentNullException(nameof(principal));

            var id = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Convert.ToInt64(id);
	    }

        public static string GetPhoneNumber(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst(ClaimTypes.MobilePhone)?.Value;
        }
    }
}
