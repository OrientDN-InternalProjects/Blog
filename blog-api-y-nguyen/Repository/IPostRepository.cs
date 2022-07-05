using blog_api_y_nguyen.Models;
using Microsoft.AspNetCore.Mvc;

namespace blog_api_y_nguyen.Repository
{
    public interface IPostRepository
    {
        bool CheckPostsExist();
        IEnumerable<Post> GetAllPosts();
        Post GetPost(int id);
        Post PutPost(Post post);
        Post PostPost(Post post);
        Post DeletePost(Post post);
        bool PostExists(int id);

    }
}