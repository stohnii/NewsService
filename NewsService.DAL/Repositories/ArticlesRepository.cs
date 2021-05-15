using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NewsService.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsService.DAL.Repositories
{
    public class ArticlesRepository : IArticlesRepository
    {
        private readonly NewsDbContext _context;

        public ArticlesRepository(NewsDbContext context)
        {
            _context = context;
        }

        public async Task<EntityEntry<Article>> AddAsync(Article article)
        {
            return await _context.Articles.AddAsync(article);
        }

        public async Task<IEnumerable<Article>> GetByAuthorIdAsync(int authorId, bool onlyActive = true)
        {
            return await _context.Articles.Where(a => a.AuthorId == authorId 
                                                    && onlyActive ? a.IsDeleted == false : true)
                                            .ToListAsync();
        }

        public async Task<Article> GetByIdAsync(int articleId)
        {
            return await _context.Articles.FindAsync(articleId);
        }

        public async Task<Article> UpdateAsync(Article article)
        {
            var existingArticle = await _context.Articles.FindAsync(article.Id);

            existingArticle.Title = article.Title;
            existingArticle.Description = article.Description;
            existingArticle.Text = article.Text;
            existingArticle.IsDeleted = article.IsDeleted;
            existingArticle.PublishDate = article.PublishDate;

            return existingArticle;
        }
    }
}
