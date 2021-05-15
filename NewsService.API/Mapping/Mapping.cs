using AutoMapper;
using NewsService.BAL.DTOs;
using NewsService.DAL.Entities;

namespace NewsService.API.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<AuthorDto, Author>().ReverseMap();
            CreateMap<ArticleDto, Article>().ReverseMap();
        }
    }
}
