using System.Text.Json.Serialization;

namespace WebApi.HttpResponse;

public interface IHttpResponseResult<T> {
  T? Data { get; set; }
  bool? Status { get; set; }
  string? Message { get; set; }
}

public class HttpResponseResult<T> : IHttpResponseResult<T> {


  public HttpResponseResult(bool status, T data){
    this.Data = data;
    this.Status = status;
  }

    public HttpResponseResult(bool status, string message){
    this.Message = message;
    this.Status = status;
  }

  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public T? Data { get; set; }

  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public bool? Status { get; set; }

  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? Message { get; set; }
}
