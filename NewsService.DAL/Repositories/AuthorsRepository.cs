using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NewsService.DAL.Entities;
using System.Threading.Tasks;

namespace NewsService.DAL.Repositories
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly NewsDbContext _context;

        public AuthorsRepository(NewsDbContext context)
        {
            _context = context;
        }

        public async Task<EntityEntry<Author>> AddAsync(Author author)
        {
            return await _context.Authors.AddAsync(author);
        }

        public async Task<Author> GetByIdAsync(int authorId)
        {
            return await _context.Authors.FindAsync(authorId);
        }

        public async Task<Author> UpdateAsync(Author autor)
        {
            var existingAuthor = await _context.Authors.FirstOrDefaultAsync(a => a.Id == autor.Id);

            existingAuthor.FullName = autor.FullName;
            existingAuthor.IsActive = autor.IsActive;

            return existingAuthor;
        }
    }
}
