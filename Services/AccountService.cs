using WebApi.Models;
using WebApi.ModelDTO;
using BC = BCrypt.Net.BCrypt;

namespace WebApi.Services;


public interface IAccountService
{
  bool Register(UserDTO model);
  User? Authenticate(SessionParams model);
}

public class AccountService : IAccountService
{
  private DataContext _context;

  public AccountService(DataContext context)
  {
    this._context = context;
  }

  public bool Register(UserDTO model)
  {
    var account = new User(model.Name, model.Email, model.Password);

    account.Password = BC.HashPassword(account.Password);
    var result = _context?.Users?.Add(account);
    _context?.SaveChanges();

    if (result is not null) {
      return true;
    }
    return false;
  }

  public User? Authenticate(SessionParams model)
  {
    var account = _context?.Users?.SingleOrDefault(u => u.Email == model.Email);

    if (account == null || !BC.Verify(model.Password, account.Password))
    {
      return null;
    }

    return account;
  }
}