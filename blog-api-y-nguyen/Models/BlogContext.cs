using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
namespace blog_api_y_nguyen.Models
{
    public class BlogContext : DbContext
    {
        private Func<object, object> value;

        public BlogContext(DbContextOptions<BlogContext> options)
           : base(options)
        {
        }

        public BlogContext(Func<object, object> value)
        {
            this.value = value;
        }

        public DbSet<Blog> Authors { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;
        public DbSet<Blog> Blogs { get; set; } = null!;
    }
}
