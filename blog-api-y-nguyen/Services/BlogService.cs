using blog_api_y_nguyen.Models;
using blog_api_y_nguyen.Repository;
using Microsoft.AspNetCore.Mvc;
namespace blog_api_y_nguyen.Services
{
    public class BlogService : IBlogService
    {
        private IBlogRepository _blogRepository;
        public BlogService(BlogContext context)
        {
            _blogRepository = new BlogRepository(context);
        }

        // Check whether Blogs is exist or not:
        public bool CheckBlogsIsExist()
        {
            return _blogRepository.CheckBlogsExist();
        }

        // GET: api/Blogs
        public ActionResult<IEnumerable<Blog>> GetAllAuthors()
        {
            return _blogRepository.GetAllBlogs();
        }

        // GET: api/Blogs/5
        public Blog GetAuthor(int id)
        {
            return _blogRepository.GetBlog(id);
        }

        // PUT: api/Blogs/5
        public void PutAuthor(Blog blog)
        {
            _blogRepository.PutBlog(blog);
            _blogRepository.Save();
        }

        // POST: api/Blogs
        public void PostAuthor(Blog blog)
        {
            _blogRepository.PostBlog(blog);
            _blogRepository.Save();
        }

        // DELETE: api/Blogs/5
        public void DeleteAuthor(Blog blog)
        {
            _blogRepository.DeleteBlog(blog);
            _blogRepository.Save();
        }

        // Save Change:
        public void Save()
        {
            _blogRepository.Save();
        }

        // Check Blogs Exists:
        public bool BlogExists(int id)
        {
            return _blogRepository.BlogExists(id);
        }
    }
}
