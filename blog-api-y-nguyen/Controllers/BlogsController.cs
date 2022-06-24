using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using blog_api_y_nguyen.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using System.Configuration;

using Microsoft.Extensions.Configuration;
using blog_api_y_nguyen.Repository;

namespace blog_api_y_nguyen.Controllers
{
    [Route("api/blogs")]
    [ApiController]
    public class BlogsController : Controller
    {
        private IBlogRepository _blogRepository;
        private readonly BlogContext _context;

        public BlogsController(BlogContext context)
        {
            _context = context;
            _blogRepository = new BlogRepository(_context);
        }

        // GET: api/Blogs
        [HttpGet]
        public IEnumerable<Blog> GetAllBlogs()
        {
            return _blogRepository.GetAllBlogs();
        }

        // GET: api/Blogs/5
        [HttpGet("{id}")]
        public Blog GetBlog(int id)
        {
            return _blogRepository.GetBlog(id);
        }

        // PUT: api/Blogs/5
        [HttpPut]
        public void PutBlog(Blog blog)
        {
            _blogRepository.PutBlog(blog);
            _blogRepository.Save();
        } 

        // POST: api/Blogs
        [HttpPost]
        public void PostBlog(Blog blog)
        {
            _blogRepository.PostBlog(blog);
            _blogRepository.Save();
        }

        // DELETE: api/Blogs/5
        [HttpDelete("{id}")]
        public void DeleteBlog(Blog blog)
        {
            _blogRepository.DeleteBlog(blog);
            _blogRepository.Save();
        }
    }
}
