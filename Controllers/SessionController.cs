using Microsoft.AspNetCore.Mvc;
using WebApi.Authorization;
using WebApi.ModelDTO;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]

public class SessionController : ControllerBase {

  private readonly AccountService _accountService;

  public SessionController(AccountService accountService) {
    this._accountService = accountService;
  }

  [AllowAnonymousAttribute]
  [HttpPost(Name = "Sign In")]
  public ActionResult<SignInResponse> SignIn([FromBody] SessionParams session)
  {
    var user = _accountService.Authenticate(session);
    if (user is null){

      return Unauthorized(new SignInResponse(accessToken: null!, errorMessage: "Invalid username or password"));
    }

    var authenticatedData = JwtUtils.GenerateToken(user);

    return Ok(new SignInResponse(accessToken: authenticatedData, errorMessage: null!));
  }
}