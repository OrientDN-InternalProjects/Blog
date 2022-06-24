using blog_api_y_nguyen.Models;
namespace blog_api_y_nguyen.Repository
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetAllBlogs();
        Blog GetBlog(int id);
        void PutBlog(Blog blog);
        void PostBlog(Blog blog);
        void DeleteBlog(Blog blog);
        void Save();
    }
}