using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using blog_api_y_nguyen.Models;
using blog_api_y_nguyen.Repository;
using blog_api_y_nguyen.Services;
using AutoMapper;

namespace blog_api_y_nguyen.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        // GET: api/Posts
        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetAllPosts()
        {
            if (!_postService.CheckPostsExist())
            {
                return NotFound();
            }
            return Ok(_postService.GetAllPosts());
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public ActionResult<Post> GetPost(int id)
        {
            if (!_postService.CheckPostsExist())
            {
                return NotFound();
            }
            var post = _postService.GetPost(id);
            if (post == null)
            {
                return NotFound();
            }
            return post;
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public IActionResult PutPost(int id, Post post)
        {
            if (id != post.BlogId)
            {
                return BadRequest();
            }
            if (!_postService.PostExists(id))
            {
                return NotFound();
            }
            else
            {
                _postService.PutPost(post);
                return Ok();
            }
        }

        // POST: api/Posts
        [HttpPost]
        public ActionResult<Post> PostPost(Post post)
        {
            if (!_postService.CheckPostsExist())
            {
                return Problem("Entity set 'PostContext.Posts'  is null.");
            }
            _postService.PostPost(post);
            return CreatedAtAction(nameof(GetPost), new { id = post.PostId }, post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            if (!_postService.CheckPostsExist())
            {
                return NotFound();
            }
            var PostToBeDeleted = _postService.GetPost(id);
            if (PostToBeDeleted == null)
            {
                return NotFound();
            }
            _postService.DeletePost(PostToBeDeleted);
            return Ok();
        }
    }
}
