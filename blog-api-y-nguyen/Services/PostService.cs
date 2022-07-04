using blog_api_y_nguyen.Models;
using blog_api_y_nguyen.Repository;
using Microsoft.AspNetCore.Mvc;
namespace blog_api_y_nguyen.Services
{
    public class PostService : IPostService
    {
        private IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        // Check whether Posts is exist or not:
        public bool CheckPostsExist()
        {
            return _postRepository.CheckPostsExist();
        }

        // GET: api/Posts
        public IEnumerable<Post> GetAllPosts()
        {
            return _postRepository.GetAllPosts();
        }

        // GET: api/Posts/5
        public Post GetPost(int id)
        {
            return _postRepository.GetPost(id);
        }

        // PUT: api/Posts/5
        public void PutPost(Post post)
        {
            _postRepository.PutPost(post);
        }

        // POST: api/Posts
        public void PostPost(Post post)
        {
            _postRepository.PostPost(post);
        }

        // DELETE: api/Posts/5
        public void DeletePost(Post post)
        {
            _postRepository.DeletePost(post);
        }

        // Check Post Exists:
        public bool PostExists(int id)
        {
            return _postRepository.PostExists(id);
        }
    }
}
