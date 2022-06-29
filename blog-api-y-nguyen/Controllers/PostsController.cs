using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using blog_api_y_nguyen.Models;
using blog_api_y_nguyen.Repository;

namespace blog_api_y_nguyen.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : Controller
    {
        private IPostRepository _postRepository;
        public PostsController (BlogContext context)
        {
            _postRepository = new PostRepository(context);
        }

        // GET: api/Posts
        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetAllPosts()
        {
            if (_postRepository.CheckPostsExist() == false)
            {
                return NotFound();
            }
            return _postRepository.GetAllPosts();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public ActionResult<Post> GetPost(int id)
        {
            if (_postRepository.CheckPostsExist() == false)
            {
                return NotFound();
            }
            var post = _postRepository.GetPost(id);
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
            if (id != post.PostId)
            {
                return BadRequest();
            }
            _postRepository.PutPost(post);
            try
            {
                _postRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_postRepository.PostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

        // POST: api/Posts
        [HttpPost]
        public ActionResult<Post> PostPost(Post post)
        {
            if (_postRepository.CheckPostsExist() == false)
            {
                return Problem("Entity set 'BlogContext.Posts'  is null.");
            }
            _postRepository.PostPost(post);
            _postRepository.Save();
            return CreatedAtAction(nameof(GetPost), new { id = post.PostId }, post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            if (_postRepository.CheckPostsExist() == false)
            {
                return NotFound();
            }
            var postDel = _postRepository.GetPost(id);
            if (postDel == null)
            {
                return NotFound();
            }
            _postRepository.DeletePost(postDel);
            _postRepository.Save();
            return Ok();

        }
    }
}
