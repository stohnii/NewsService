using AutoMapper;
using NewsService.BAL.DTOs;
using NewsService.DAL;
using NewsService.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace NewsService.BAL
{
    public class AuthorsManager : BaseManager, IAuthorsManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsManager(IUnitOfWork unitOfWork, IMapper mapper)
            : base(mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AuthorDto> AddOrUpdateAsync(AuthorDto author)
        {
            try
            {
                var existedAuthor = await _unitOfWork.Authors.GetByIdAsync(author.Id);

                if (existedAuthor == null)
                {
                    var entity = await _unitOfWork.Authors.AddAsync(Mapper.Map<Author>(author));
                    await _unitOfWork.CommitAsync();
                    return Mapper.Map<AuthorDto>(entity.Entity);
                }
                else
                {
                    var result = await _unitOfWork.Authors.UpdateAsync(Mapper.Map<Author>(author));
                    await _unitOfWork.CommitAsync();
                    return Mapper.Map<AuthorDto>(result);
                }
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<AuthorDto> GetByIdAsync(int authorId)
        {
            var entity = await _unitOfWork.Authors.GetByIdAsync(authorId);
            return Mapper.Map<AuthorDto>(entity);
        }
    }
}
