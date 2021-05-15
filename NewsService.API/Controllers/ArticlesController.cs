using Microsoft.AspNetCore.Mvc;
using NewsService.BAL;
using NewsService.BAL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticlesManager _articlesManager;

        public ArticlesController(IArticlesManager articlesManager)
        {
            _articlesManager = articlesManager;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArticleDto>> GetByIdAsync(int id)
        {
            var result = await _articlesManager.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("byauthor/{authorId}/{onlyActive}")]
        public async Task<ActionResult<IEnumerable<ArticleDto>>> GetByAuthorIdAsync(int authorId, bool onlyActive = true)
        {
            var result = await _articlesManager.GetByAuthorIdAsync(authorId, onlyActive);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ArticleDto>> AddOrUpdateAsync([FromBody] ArticleDto article)
        {
            var result = await _articlesManager.AddOrUpdateAsync(article);
            return Ok(result);
        }
    }
}
