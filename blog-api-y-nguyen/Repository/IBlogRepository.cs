using blog_api_y_nguyen.Models;
using Microsoft.AspNetCore.Mvc;

namespace blog_api_y_nguyen.Repository
{
    public interface IBlogRepository
    {
        bool CheckBlogsExist();
        IEnumerable<Blog> GetAllBlogs();
        Blog GetBlog(int id);
        Blog PutBlog(Blog blog);
        Blog PostBlog(Blog blog);
        Blog DeleteBlog(Blog blog);
        bool BlogExists(int id);

    }
}