using System.Text.Json.Serialization;

namespace WebApi.ModelDTO;

public class SessionParams {
  public SessionParams(string email, string password)
  {
    this.Email = email;
    this.Password = password;
  }

  public string Email { get; }
  public string Password { get; }
}

public class UserDTO
{
  public UserDTO(string name, string email, string password)
  {
    this.Name = name;
    this.Email = email;
    this.Password = password;
  }

  public string Name { get; }
  public string Email { get; }
  public string Password { get; private set; }
}

public class UserPublicInfo
{
  public UserPublicInfo(string name, string email)
  {
    this.Name = name;
    this.Email = email;
  }
  [JsonInclude]
  public string Name { get; }
  [JsonInclude]
  public string Email { get; }
}