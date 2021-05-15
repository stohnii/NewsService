using NewsService.DAL.Repositories;
using System.Threading.Tasks;

namespace NewsService.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NewsDbContext _context;
        private IArticlesRepository _articlesRepo;
        private IAuthorsRepository _authorsRepo;

        public UnitOfWork(NewsDbContext context)
        {
            _context = context;
        }

        public IAuthorsRepository Authors => _authorsRepo ?? new AuthorsRepository(_context);

        public IArticlesRepository Articles => _articlesRepo ?? new ArticlesRepository(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task RollbackAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
