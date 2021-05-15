using AutoMapper;
using NewsService.BAL.DTOs;
using NewsService.DAL;
using NewsService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsService.BAL
{
    public class ArticlesManager : BaseManager, IArticlesManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticlesManager(IUnitOfWork unitOfWork, IMapper mapper)
            : base(mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ArticleDto> AddOrUpdateAsync(ArticleDto article)
        {
            try
            {
                if (article.Id == 0)
                {
                    article.PublishDate = DateTime.UtcNow;
                    var result = await _unitOfWork.Articles.AddAsync(Mapper.Map<Article>(article));
                    await _unitOfWork.CommitAsync();
                    return Mapper.Map<ArticleDto>(result.Entity);
                }
                else
                {
                    var result = await _unitOfWork.Articles.UpdateAsync(Mapper.Map<Article>(article));
                    await _unitOfWork.CommitAsync();
                    return Mapper.Map<ArticleDto>(result);
                }
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public async Task<IEnumerable<ArticleDto>> GetByAuthorIdAsync(int authorId, bool onlyActive = true)
        {
            var articles = await _unitOfWork.Articles.GetByAuthorIdAsync(authorId, onlyActive);
            return articles.Select(a => Mapper.Map<ArticleDto>(a));
        }

        public async Task<ArticleDto> GetByIdAsync(int articleId)
        {
            var article = await _unitOfWork.Articles.GetByIdAsync(articleId);
            return Mapper.Map<ArticleDto>(article);
        }
    }
}
