using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNet.Security.OpenIdConnect.Primitives;
using Microsoft.AspNetCore.Http;

namespace ElectionHawk.Web.Identity
{
    public static class IdentityExtensions
    {
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));
            var id = principal.FindFirst(OpenIdConnectConstants.Claims.Subject)?.Value;
            return Convert.ToInt32(id);
        }

        //public static Task<ElectionHawkIdentityUser> GetCurrentUserAsync(this HttpContext httpContext)
        //{
        //    return _userManager.GetUserAsync(httpContext.User);
        //}

    }
}
