using System.Threading.Tasks;
using CoreNative.ArticleManagement.Entities.Concrete;
using CoreNative.ArticleManagement.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreNative.ArticleManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleCommentsController : ControllerBase
    {
        private readonly IArticleCommentService _articleCommentService;
        public ArticleCommentsController(IArticleCommentService articleCommentService)
        {
            _articleCommentService = articleCommentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _articleCommentService.GetAllAsync());
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _articleCommentService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(ArticleComment articleComment)
        {
            return Ok(await _articleCommentService.AddAsync(articleComment));
        }

        [HttpPut]
        public async Task Update(ArticleComment articleComment)
        {
            await _articleCommentService.UpdateAsync(articleComment);
        }

        [HttpDelete, Route("{id}")]
        public async Task Delete(int id)
        {
            await _articleCommentService.DeleteAsync(new ArticleComment { ArticleCommentId = id });
        }
    }
}