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
        public IEnumerable<Post> GetAllPosts()
        {
            return _postRepository.GetAllPosts();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public Post GetPost(int id)
        {
            return _postRepository.GetPost(id);
        }

        // PUT: api/Posts/5
        [HttpPut]
        public void PutPost(Post post)
        {
            _postRepository.PutPost(post);
            _postRepository.Save();
        }

        // POST: api/Posts
        [HttpPost]
        public void PostPost(Post post)
        {
            _postRepository.PostPost(post);
            _postRepository.Save();
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public void DeletePost(Post post)
        {
            _postRepository.DeletePost(post);
            _postRepository.Save();
        }
    }
}
