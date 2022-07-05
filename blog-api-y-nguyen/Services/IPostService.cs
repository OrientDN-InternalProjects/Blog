using blog_api_y_nguyen.Models;
using Microsoft.AspNetCore.Mvc;
namespace blog_api_y_nguyen.Services
{
    public interface IPostService
    {
        bool CheckPostsExist();
        IEnumerable<Post> GetAllPosts();
        Post GetPost(int id);
        void PutPost(Post post);
        void PostPost(Post post);
        void DeletePost(Post post);
        bool PostExists(int id);
    }
}