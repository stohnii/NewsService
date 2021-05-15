using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NewsService.DAL.Entities
{
    public class Author
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        public bool IsActive { get; set; }

        public virtual IEnumerable<Article> Articles { get; set; }
    }
}
