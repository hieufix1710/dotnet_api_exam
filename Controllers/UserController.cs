using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Authorization;
using WebApi.ModelDTO;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
[AuthorizeAttribute]
public class UserController : ControllerBase
{

  private readonly UserService _userService;
  private readonly AccountService _accountService;

  public UserController(UserService service, AccountService accountService)
  {
    this._userService = service;
    this._accountService = accountService;
  }

  [HttpGet(Name = "List Users")]
  public ActionResult<IEnumerable<User>> Get()
  {
    var users = _userService.GetUsers();
    return Ok(users);
  }

  [AllowAnonymousAttribute]
  [HttpPost(Name = "Current Users")]
  public ActionResult<string> Register(UserDTO user)
  {
    if (this._accountService.Register(user))
    {
      return Ok("Registration successfully.");
    }
    return BadRequest("Registration failed.");

  }
}