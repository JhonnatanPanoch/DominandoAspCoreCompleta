using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;

namespace AspNetCoreIdentity.Web.Extensions
{
    public static class RazorExtensions
    {
        public static bool IfClaim(this RazorPage page, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidateClaimsUser(page.Context, claimName, claimValue);
        }

        public static string IfClaimShow(this RazorPage page, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidateClaimsUser(page.Context, claimName, claimValue) ? "" : "disabled";
        }

        public static IHtmlContent IfClaimShow(this IHtmlContent page, HttpContext httpcontext, string claimName, string claimValue)
        {
            return CustomAuthorization.ValidateClaimsUser(httpcontext, claimName, claimValue) ? page : null;
        }
    }
}
