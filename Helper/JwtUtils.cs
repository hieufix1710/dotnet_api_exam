

using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApi.Models;

namespace WebApi.Helpers;

public class JwtUtils
{
  private static readonly string secretKey = "asdhasdfhasfnasdfhasdjfasf";

  private readonly UserService _userService;
  private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

  public JwtUtils(UserService userService)
  {
    this._userService = userService;
    this._jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
  }
  public static string GenerateToken(User user)
  {
    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
    var signingCredentials = new SigningCredentials(securityKey, "HS256");
    var securityToken = new JwtSecurityToken(
           signingCredentials: signingCredentials,
           issuer: "dotnet",
           audience: "dotnet",
           claims: new[]
           {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim("email", user.Email)
           },
           expires: DateTime.UtcNow.AddMinutes(1));
    return new JwtSecurityTokenHandler().WriteToken(securityToken);
  }
  public bool ValidateToken(string? authToken)
  {
    try
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var validationParameters = GetValidationParameters();
      SecurityToken validatedToken;
      ClaimsPrincipal c = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
      if (validatedToken != null) return false;
      return true;
    }
    catch (Exception e)
    {

      Console.WriteLine("Failed to validate token: " + e.Message);
    }
    return false;
  }


  private static TokenValidationParameters GetValidationParameters()
  {
    return new TokenValidationParameters()
    {
      ValidateIssuerSigningKey = false,
      ValidateLifetime = true,
      ValidateAudience = false,
      ValidateIssuer = false,
      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
    };
  }
}
