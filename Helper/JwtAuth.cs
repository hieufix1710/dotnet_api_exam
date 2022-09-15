using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApi.ModelDTO;

namespace WebApi.Helpers;


public class JwtAuth
{
  private static readonly string secretKey = "asdhasdfhasfnasdfhasdjfasf";

  public static string? getRefreshToken(TokenResponse tokens)
  {
    try
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      SecurityToken validatedToken;
      ClaimsPrincipal c = tokenHandler.ValidateToken(tokens.access_token, new TokenValidationParameters()
      {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidAudience = "dotnet",
        ValidIssuer = "dotnet",
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
        ValidateLifetime = false
      },
      out validatedToken);
      var tokenValidated = (JwtSecurityToken)validatedToken;
      var email = tokenValidated.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);

      if (validatedToken != null)
        
      {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var signingCredentials = new SigningCredentials(securityKey, "HS256");
        var newAccessToken = new JwtSecurityToken(
               signingCredentials: signingCredentials,
               issuer: "dotnet",
               audience: "dotnet",
               claims: new[]
               {
                new Claim(JwtRegisteredClaimNames.Sub, email!.Value),
               },
               expires: DateTime.UtcNow.AddMinutes(1));
        return new JwtSecurityTokenHandler().WriteToken(newAccessToken);

      }
    }
    catch (Exception e)
    {
      Console.WriteLine("Failed to validate token: " + e.Message);
    }
    return null;
  }

  public static ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
  {
    var tokenValidationParameters = new TokenValidationParameters
    {
      ValidateAudience = true, //you might want to validate the audience and issuer depending on your use case
      ValidateIssuer = true,
      ValidAudience = "dotnet",
      ValidIssuer = "dotnet",
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
      ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
    };
    var tokenHandler = new JwtSecurityTokenHandler();
    SecurityToken securityToken;
    var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
    var jwtSecurityToken = securityToken as JwtSecurityToken;
    if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
      throw new SecurityTokenException("Invalid token");
    return principal;
  }

}