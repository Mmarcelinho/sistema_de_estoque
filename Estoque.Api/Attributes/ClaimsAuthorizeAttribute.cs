using System.Security.Claims;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Estoque.Api.Attributes;

    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimType, string claimValue) : base(typeof(ClaimsAuthorizationRequirement)) =>
            Arguments = new object[] { new Claim(claimType, claimValue) };
    }

    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        readonly Claim _claim;

        public ClaimRequirementFilter(Claim claim) =>
            _claim = claim;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User as ClaimsPrincipal;

#pragma warning disable CS8602 // Desrefer�ncia de uma refer�ncia possivelmente nula.
            if(user == null || !user.Identity.IsAuthenticated)
            {
               context.Result = new UnauthorizedResult();
               return; 
            }
#pragma warning restore CS8602 // Desrefer�ncia de uma refer�ncia possivelmente nula.

            if(!user.HasClaim(_claim.Type, _claim.Value))
            context.Result = new ForbidResult();
        }
    }