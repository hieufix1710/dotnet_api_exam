using WebApi.Models;

namespace WebApi.Services;
public class UserService
{

  private readonly DataContext _dataContext;

  public UserService(DataContext dataContext)
  {
    this._dataContext = dataContext;
  }

  public IEnumerable<User>? GetUsers()
  {
    var users = this._dataContext.Users;
    return users;
  }

  public User? GetUserByEmail(string email)
  {
    return this._dataContext.Users?.FirstOrDefault(u => u.Email == email);
  }
  public User? GetUserById(int id)
  {
    return this._dataContext.Users?.FirstOrDefault(u => u.ID == id);
  }
}