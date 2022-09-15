using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models;
public class Article
{
  public Article(){

  }
  public Article(string title, string description, User author, List<Image> images)
  {
    this.Title = title; this.Description = description; this.Author = author;
    this.Images = images;
  }

  [Column("ID")]
  [JsonInclude]
  public int ID { get; set; }
  [Column("Title")]
  [JsonInclude]
  public string Title { get; set; }
  [Column("Description")]
  [JsonInclude]
  public string Description { get; set; }

  [Column("AuthorID")]
  [JsonInclude]
  public int AuthorID { get; set; }

  public User Author { get; set; }

  [JsonInclude]
  public ICollection<Image> Images { get; set; } = new List<Image>();

  [Column("CreatedAt")]
  [JsonInclude]
  public DateTime CreatedAt { get; set; }

}