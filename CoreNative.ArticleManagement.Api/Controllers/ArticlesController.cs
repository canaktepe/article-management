using System.Threading.Tasks;
using CoreNative.ArticleManagement.Business.Abstract;
using CoreNative.ArticleManagement.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreNative.ArticleManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _articleService.GetAllAsync());
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _articleService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Article article)
        {
            return Ok(await _articleService.AddAsync(article));
        }

        [HttpPut]
        public async Task Update(Article article)
        {
            await _articleService.UpdateAsync(article);
        }

        [HttpDelete, Route("{id}")]
        public async Task Delete(int id)
        {
            await _articleService.DeleteAsync(new Article { ArticleId = id });
        }

        [HttpGet, Route("search/{keyword}")]
        public async Task<IActionResult> SearchArticlesByKeyword(string keyword)
        {
            return Ok(await _articleService.SearchArticlesByKeyword(keyword));
        }
    }
}