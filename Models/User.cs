using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models;
public class User
{
  public User()
  {

  }

  public User(string name, string email, string password)
  {
    this.Name = name;
    this.Email = email;
    this.Password = password;
  }
  public User(int id, string name, string email, string password)
  {
    this.ID = id;
    this.Name = name;
    this.Email = email;
    this.Password = password;
  }
  [Column("ID")]
  [JsonInclude]
  public int ID { get; set; }
  [Column("Name")]
  [JsonInclude]
  public string? Name { get; set; }
  [Column("Email")]
  [JsonInclude]
  public string Email { get; set; }

  [Column("Password")]
  [JsonIgnore]
  public string Password { get; set; }

  public ICollection<Article>? Articles { get; set; }

  [Column("CreatedAt")]
  [JsonInclude]
  public DateTime createdAt { get; set; }
}