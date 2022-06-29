using blog_api_y_nguyen.Models;
using blog_api_y_nguyen.Repository;
using Microsoft.AspNetCore.Mvc;
namespace blog_api_y_nguyen.Services
{
    public class PostService : IPostService
    {
        private IPostRepository _postRepository;
        public PostService(BlogContext context)
        {
            _postRepository = new PostRepository(context);
        }

        // Check whether Posts is exist or not:
        public bool CheckPostsExist()
        {
            return _postRepository.CheckPostsExist();
        }

        // GET: api/Posts
        public ActionResult<IEnumerable<Post>> GetAllPosts()
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
            _postRepository.Save();
        }

        // POST: api/Posts
        public void PostPost(Post post)
        {
            _postRepository.PostPost(post);
            _postRepository.Save();
        }

        // DELETE: api/Posts/5
        public void DeletePost(Post post)
        {
            _postRepository.DeletePost(post);
            _postRepository.Save();
        }

        // Save Change:
        public void Save()
        {
            _postRepository.Save();
        }

        // Check Post Exists:
        public bool PostExists(int id)
        {
            return _postRepository.PostExists(id);
        }
    }
}
