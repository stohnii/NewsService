using System;
using System.ComponentModel.DataAnnotations;

namespace NewsService.DAL.Entities
{
    public class Article
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public int AuthorId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime PublishDate { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Author Author { get; set; }
    }
}
