using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace DevIO.App.Extensions
{
    [HtmlTargetElement("*", Attributes = "suppress-by-claim-name")]
    [HtmlTargetElement("*", Attributes = "suppress-by-claim-value")]
    public class SuppressByClaimTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SuppressByClaimTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HtmlAttributeName("suppress-by-claim-name")]
        public string IdentityClaimName { get; set; }

        [HtmlAttributeName("suppress-by-claim-value")]
        public string IdentityClaimValue { get; set; }

        public override void Process(
            TagHelperContext context, 
            TagHelperOutput output)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (output == null)
                throw new ArgumentNullException(nameof(context));

            bool hasAccess = CustomAuthorization.ValidateClaimsUser(
                _httpContextAccessor.HttpContext,
                IdentityClaimName,
                IdentityClaimValue);

            if (hasAccess)
                return;

            output.SuppressOutput();
        }
    }
}