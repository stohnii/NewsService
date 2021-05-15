using NewsService.BAL.DTOs;
using System.Threading.Tasks;

namespace NewsService.BAL
{
    public interface IAuthorsManager
    {
        Task<AuthorDto> GetByIdAsync(int authorId);
        Task<AuthorDto> AddOrUpdateAsync(AuthorDto author);
    }
}
