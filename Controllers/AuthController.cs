using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.ModelDTO;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]

public class AuthController : ControllerBase
{

  private readonly AccountService _accountService;

  public AuthController(AccountService accountService)
  {
    this._accountService = accountService;
  }

  [AllowAnonymousAttribute]
  [HttpPost(Name = "Refresh Token")]
  public ActionResult<TokenResponse> RefreshToken([FromBody] TokenResponse tokens)
  {
    var newAccessToken = JwtAuth.getRefreshToken(tokens);

    return Ok(new TokenResponse(access_token: newAccessToken!));
  }
}
