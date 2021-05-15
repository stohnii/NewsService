using System;

namespace NewsService.BAL.DTOs
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsDeleted { get; set; }
        public AuthorDto Author { get; set; }
    }
}
