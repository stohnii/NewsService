using Microsoft.EntityFrameworkCore.ChangeTracking;
using NewsService.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsService.DAL.Repositories
{
    public interface IArticlesRepository
    {
        Task<Article> GetByIdAsync(int articleId);
        Task<IEnumerable<Article>> GetByAuthorIdAsync(int authorId, bool onlyActive = true);
        Task<Article> UpdateAsync(Article article);
        Task<EntityEntry<Article>> AddAsync(Article article);
    }
}
