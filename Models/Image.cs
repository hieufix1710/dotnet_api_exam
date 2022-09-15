using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models;
public class Image
{

  public Image()
  {

  }
  public Image(string url, Article Article)
  {
    this.Url = url;
    this.Article = Article;
  }

  [Column("ID")]
  [JsonInclude]
  public int ID { get; set; }

  [Column("Url")]
  [JsonInclude]
  public string Url { get; set; }

  [Column("ArticleID")]
  [JsonInclude]
  public int ArticleID { get; set; }
  public Article Article { get; set; }

  [Column("CreatedAt")]
  public DateTime CreatedAt { get; set; }
}
