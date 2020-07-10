using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace auth_server.Utils
{
    public static class JwtClaim
    {
        public static Guid GetID(ClaimsPrincipal principal)
        {

            foreach (Claim claim in principal.Claims)
            {
                if (claim.Type == ClaimTypes.Name)
                {
                    return Guid.Parse(claim.Value);
                }
            }
            throw new Exception("User claim was not found");
        }
    }
}