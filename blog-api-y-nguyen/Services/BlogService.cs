using blog_api_y_nguyen.Models;
using blog_api_y_nguyen.Repository;
using Microsoft.AspNetCore.Mvc;
namespace blog_api_y_nguyen.Services
{
    public class BlogService : IBlogService
    {
        private IBlogRepository _blogRepository;
        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        // Check whether Blogs is exist or not:
        public bool CheckBlogsExist()
        {
            return _blogRepository.CheckBlogsExist();
        }

        // GET: api/Blogs
        public IEnumerable<Blog> GetAllBlogs()
        {
            return _blogRepository.GetAllBlogs();
        }

        // GET: api/Blogs/5
        public Blog GetBlog(int id)
        {
            return _blogRepository.GetBlog(id);
        }

        // PUT: api/Blogs/5
        public void PutBlog(Blog blog)
        {
            _blogRepository.PutBlog(blog);
        }

        // POST: api/Blogs
        public void PostBlog(Blog blog)
        {
            _blogRepository.PostBlog(blog);
        }

        // DELETE: api/Blogs/5
        public void DeleteBlog(Blog blog)
        {
            _blogRepository.DeleteBlog(blog);
        }

        // Check Blog Exists:
        public bool BlogExists(int id)
        {
            return _blogRepository.BlogExists(id);
        }
    }
}
