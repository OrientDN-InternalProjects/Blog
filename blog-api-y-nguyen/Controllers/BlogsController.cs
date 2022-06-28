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

        public BlogsController(BlogContext context)
        {
            _blogRepository = new BlogRepository(context);
        }

        // GET: api/Blogs
        [HttpGet]
        public ActionResult<IEnumerable<Blog>> GetAllBlogs()
        {
            if (_blogRepository.CheckBlogsIsNull())
            {
                return NotFound();
            }
            return _blogRepository.GetAllBlogs();
        }

        // GET: api/Blogs/5
        [HttpGet("{id}")]
        public ActionResult<Blog> GetBlog(int id)
        {
            if (_blogRepository.CheckBlogsIsNull())
            {
                return NotFound();
            }
            var blog = _blogRepository.GetBlog(id);
            if(blog == null)
            {
                return NotFound();
            }
            return blog;
        }

        // PUT: api/Blogs/5
        [HttpPut("{id}")]
        public IActionResult PutBlog(int id, Blog blog)
        {
            if (id != blog.BlogId)
            {
                return BadRequest();
            }
            _blogRepository.PutBlog(blog);
            try
            {
                _blogRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_blogRepository.BlogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        } 

        // POST: api/Blogs
        [HttpPost]
        public ActionResult<Blog> PostBlog(Blog blog)
        {
            if (_blogRepository.CheckBlogsIsNull())
            {
                return Problem("Entity set 'BlogContext.Blogs'  is null.");
            }
            _blogRepository.PostBlog(blog);
            _blogRepository.Save();
            return CreatedAtAction(nameof(GetBlog), new { id = blog.BlogId }, blog);
        }

        // DELETE: api/Blogs/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            if (_blogRepository.CheckBlogsIsNull())
            {
                return NotFound();
            }
            var blogDel = _blogRepository.GetBlog(id);
            if (blogDel == null)
            {
                return NotFound();
            }
            _blogRepository.DeleteBlog(blogDel);
            _blogRepository.Save();
            return NoContent();
        }
    }
}
