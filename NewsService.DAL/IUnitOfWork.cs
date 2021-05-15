using NewsService.DAL.Repositories;
using System.Threading.Tasks;

namespace NewsService.DAL
{
    public interface IUnitOfWork
    {
        IAuthorsRepository Authors { get; }
        IArticlesRepository Articles { get; }
        Task CommitAsync();
        Task RollbackAsync();
    }
}
