using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Authorization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
  public void OnAuthorization(AuthorizationFilterContext context)
  {
    // skip authorization if action is decorated with [AllowAnonymous] attribute
    var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
    if (allowAnonymous)
      return;
    // authorization
    // var user = context.HttpContext.Items["User"];
    try {
      var accessToken = context.HttpContext.Request.Headers["Authorization"].ToString();
      SecurityToken validatedToken;

      ClaimsPrincipal c = new JwtSecurityTokenHandler().ValidateToken(accessToken, new TokenValidationParameters()
      {
        ValidateLifetime = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = "dotnet",
        ValidAudience = "dotnet",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asdhasdfhasfnasdfhasdjfasf"))
      }, out validatedToken);
      if (validatedToken == null)
        context.Result = new JsonResult(new { type = "AccessTokenMissing",  message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
    }catch (Exception e) {
      context.Result = new JsonResult(new {type = "Access Denied", message =  "Invalid Authenticated Token", stack = e.Message }) { StatusCode = StatusCodes.Status401Unauthorized };
    }
    

  }

}

[AttributeUsage(AttributeTargets.Method)]
public class AllowAnonymousAttribute : Attribute
{
}
