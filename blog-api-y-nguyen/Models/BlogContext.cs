using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
namespace blog_api_y_nguyen.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
           : base(options)
        {
        }
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<Blog> Blogs { get; set; } = null!;
    }
}
