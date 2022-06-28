using blog_api_y_nguyen.Models;
using Microsoft.AspNetCore.Mvc;

namespace blog_api_y_nguyen.Repository
{
    public interface IBlogRepository
    {
        bool CheckBlogsIsNull();
        ActionResult<IEnumerable<Blog>> GetAllBlogs();
        Blog GetBlog(int id);
        void PutBlog(Blog blog);
        void PostBlog(Blog blog);
        void DeleteBlog(Blog blog);
        void Save();
        bool BlogExists(int id);

    }
}