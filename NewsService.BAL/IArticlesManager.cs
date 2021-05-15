using NewsService.BAL.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsService.BAL
{
    public interface IArticlesManager
    {
        Task<ArticleDto> GetByIdAsync(int articleId);
        Task<IEnumerable<ArticleDto>> GetByAuthorIdAsync(int authorId, bool onlyActive = true);
        Task<ArticleDto> AddOrUpdateAsync(ArticleDto article);
    }
}
