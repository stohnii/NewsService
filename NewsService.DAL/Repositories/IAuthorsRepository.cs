using Microsoft.EntityFrameworkCore.ChangeTracking;
using NewsService.DAL.Entities;
using System.Threading.Tasks;

namespace NewsService.DAL.Repositories
{
    public interface IAuthorsRepository
    {
        Task<Author> GetByIdAsync(int authorId);
        Task<Author> UpdateAsync(Author autor);
        Task<EntityEntry<Author>> AddAsync(Author author);
    }
}
