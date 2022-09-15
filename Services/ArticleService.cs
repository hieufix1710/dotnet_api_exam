using WebApi.Models;
using WebApi.ModelDTO;
namespace WebApi.Services;


public class ArticleService
{
  private readonly DataContext _dataContext;
  private readonly UserService _userService;
  private readonly ImageService _imageService;

  public ArticleService(DataContext dataContext, UserService userService, ImageService _imageService)
  {
    this._dataContext = dataContext;
    this._userService = userService;
    this._imageService = _imageService;
  }

  public IEnumerable<ArticleDTO> GetArticles()
  {
    var sqlResult = this._dataContext.Articles?.ToList();
    var articles = new List<ArticleDTO>();
    foreach (var e in sqlResult!){
      var images = this._imageService.GetImages(e.ID)!.Select(x => x.Url).ToList();
      User author = this._userService.GetUserById(e.AuthorID)!;
      articles.Add(new ArticleDTO(title: e.Title, description: e.Description, images: images, authorEmail: author.Email, authorName: author.Name!));
    }
    return articles;
  }
  public void addArticle(ArticleDTO article)
  {
    var author = this._userService.GetUserByEmail(article.AuthorEmail);

    List<Image> images = new List<Image>();
    var targetArticle = new Article(title: article.Title, author: author!, images: images, description: article.Description);

    for (var i = 0; i < article.Images?.Count() - 1; i++)
    {
      images[i] = new Image(url: article.Images![i], targetArticle);
    }
    var newArticle = new Article(title: article.Title, description: article.Description, author: author!, images: images);

    this._dataContext.Articles?.Add(newArticle);

    foreach (var image in article.Images!)
    {
      this._dataContext.Images?.Add(new Image(url: image, Article: newArticle));
    }
    this._dataContext.SaveChanges();

  }







}