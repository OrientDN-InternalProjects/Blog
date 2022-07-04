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
using blog_api_y_nguyen.Services;
using AutoMapper;

namespace blog_api_y_nguyen.Controllers
{
    [Route("api/blogs")]
    [ApiController]
    public class BlogsController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _autoMapper;

        public BlogsController(IMapper autoMapper, IBlogService blogService)
        {
            _autoMapper = autoMapper;
            _blogService = blogService;
        }

        // GET: api/Blogs
        [HttpGet]
        public ActionResult<IEnumerable<Blog>> GetAllBlogs()
        {
            if (_blogService.CheckBlogsExist() == false)
            {
                return NotFound();
            }
            return Ok(_blogService.GetAllBlogs());
        }

        // GET: api/Blogs/5
        [HttpGet("{id}")]
        public ActionResult<Blog> GetBlog(int id)
        {
            if (_blogService.CheckBlogsExist() == false)
            {
                return NotFound();
            }
            var blog = _blogService.GetBlog(id);
            if (blog == null)
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
            if (!_blogService.BlogExists(id))
            {
                return NotFound();
            }
            else
            {
                _blogService.PutBlog(blog);
                return Ok();
            }
        }

        // POST: api/Blogs
        [HttpPost]
        public ActionResult<Blog> PostBlog(Blog blog)
        {
            if (_blogService.CheckBlogsExist() == false)
            {
                return Problem("Entity set 'BlogContext.Blogs'  is null.");
            }
            _blogService.PostBlog(blog);
            return CreatedAtAction(nameof(GetBlog), new { id = blog.BlogId }, blog);
        }

        // DELETE: api/Blogs/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            if (_blogService.CheckBlogsExist() == false)
            {
                return NotFound();
            }
            var BlogToBeDeleted = _blogService.GetBlog(id);
            if (BlogToBeDeleted == null)
            {
                return NotFound();
            }
            _blogService.DeleteBlog(BlogToBeDeleted);
            return Ok();
        }
    }
}
