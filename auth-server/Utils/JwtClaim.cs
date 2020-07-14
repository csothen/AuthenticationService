using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace auth_server.Utils
{
    public static class JwtClaim
    {
        public static string GetEmail(ClaimsPrincipal principal)
        {

            foreach (Claim claim in principal.Claims)
            {
                if (claim.Type == ClaimTypes.Email)
                {
                    return claim.Value;
                }
            }
            throw new Exception("User claim was not found");
        }
    }
}