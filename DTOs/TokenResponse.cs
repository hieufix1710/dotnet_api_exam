namespace WebApi.ModelDTO;

public class TokenResponse
{

  public TokenResponse(string access_token)
  {
    this.access_token = access_token;
  }

  public string? access_token { get; set; }
}