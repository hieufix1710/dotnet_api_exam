using System.Text.Json.Serialization;
namespace WebApi.ModelDTO;

public class SignInResponse
{

  public SignInResponse(string accessToken, string errorMessage)
  {
    this.accessToken = accessToken;
    this.errorMessage = errorMessage;
  }

  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
  public string accessToken { get; set; }
  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
  public string errorMessage { get; set; }

}