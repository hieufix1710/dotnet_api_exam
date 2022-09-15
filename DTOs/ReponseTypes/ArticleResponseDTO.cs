namespace WebApi.ModelDTO;

public class ArticleResponseDTO
{

  public ArticleResponseDTO(string title, string description, string authorEmail, List<string> images)
  {
    this.AuthorEmail = authorEmail;
    this.Title = title;
    this.Description = description;
    this.Images = images;
  }
  public string Title { get; set; }
  public string Description { get; set; }
  public string AuthorEmail { get; set; }

  public List<string> Images { get; set; }
}