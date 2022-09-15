using Microsoft.AspNetCore.Mvc;
using WebApi.ModelDTO;
using WebApi.Models;
using WebApi.Authorization;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[AuthorizeAttribute]
public class ArticleController : ControllerBase
{
  private readonly ArticleService _service;
  public ArticleController(ArticleService service){
    this._service = service;
  }

  [AllowAnonymousAttribute]
  [HttpGet(Name = "articles")]
  public ActionResult<IEnumerable<ArticleDTO>> GetArticleList(){
    return Ok(this._service.GetArticles());
  }

  [HttpPost(Name = "Add article")]
  public ActionResult AddNewArticle([FromBody] ArticleDTO article){
    this._service.addArticle(article);
    return Ok();
  }

}