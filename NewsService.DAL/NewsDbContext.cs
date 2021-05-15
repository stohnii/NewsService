using Microsoft.EntityFrameworkCore;
using NewsService.DAL.Entities;

namespace NewsService.DAL
{
    public class NewsDbContext : DbContext
    {
        public NewsDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
