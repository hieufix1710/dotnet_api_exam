namespace WebApi.ModelDTO;

public class ArticleDTO
{

  public ArticleDTO(string title, string description, string authorEmail, string authorName, List<string> images)
  {
    Console.WriteLine(" " + authorEmail + " " + authorName + " " + description + " " + title + " ");
    this.AuthorEmail = authorEmail;
    this.AuthorName = authorName;
    this.Title = title;
    this.Description = description;
    this.Images = images;
    this.createdAt = DateTime.UtcNow;
  }
  public string Title { get; set; }
  public string Description { get; set; }
  public string AuthorEmail { get; set; }
  public string AuthorName { get; set; }

  public List<string> Images { get; set; }

  public DateTime createdAt { get; set; }
}