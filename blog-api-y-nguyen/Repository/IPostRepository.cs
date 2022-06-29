using blog_api_y_nguyen.Models;
using Microsoft.AspNetCore.Mvc;

namespace blog_api_y_nguyen.Repository
{
    public interface IPostRepository
    {
        bool CheckPostsExist();
        ActionResult<IEnumerable<Post>> GetAllPosts();
        Post GetPost(int id);
        void PutPost(Post post);
        void PostPost(Post post);
        void DeletePost(Post post);
        void Save();
        bool PostExists(int id);

    }
}