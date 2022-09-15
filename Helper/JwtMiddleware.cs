
namespace WebApi.Authorization;

public class JwtMiddleware
{
  private readonly RequestDelegate _next;

  public JwtMiddleware(RequestDelegate requestDelegate)
  {
    this._next = requestDelegate;
  }

  public async Task Invoke(HttpContext context, UserService userService, JwtUtils jwtUtils)
  {
    // var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
    // var userEmail = jwtUtils.ValidateToken(token);
    // if (userEmail != null)
    // {
    //   context.Items["User"] = userService.GetUserByEmail(userEmail);
    // }
    // Console.WriteLine("Invoke: " + context.Items);

    await this._next(context);
  }
}