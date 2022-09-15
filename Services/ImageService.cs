using WebApi.Models;

namespace WebApi.Services;
public class ImageService
{

  private readonly DataContext _dataContext;

  public ImageService(DataContext dataContext)
  {
    this._dataContext = dataContext;
  }

  public IEnumerable<Image>? GetImages(int articleID)
  {
    var images = this._dataContext.Images?.Where(image => image.ArticleID == articleID);
    return images;
  }

}