using System.Collections.Generic;
using System.Security.Claims;
using Codar.Net.Users.Models;

namespace Codar.Net.Users.Extensions
{
    public static class RoleClaimsExtension
        {
            public static IEnumerable<Claim> GetClaims(this User user)
            {
                var result = new List<Claim>
                {
                    new(ClaimTypes.Name, user.Email),
                    new(ClaimTypes.Role, user.Role.ToString())
                };

                return result;
            }
        }
}