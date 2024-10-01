﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Common.AspNetCore
{
    public static class ClaimUtils
    {
	    public static int GetUserId(this ClaimsPrincipal principal)
	    {
		    if (principal == null)
			    throw new ArgumentNullException(nameof(principal));
		    return Convert.ToInt32(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
	    }
	}
}
