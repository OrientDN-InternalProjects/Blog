using blog_api_y_nguyen.Models;
namespace blog_api_y_nguyen.Repository
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAllPosts();
        Post GetPost(int id);
        void PutPost(Post post);
        void PostPost(Post post);
        void DeletePost(Post post);
        void Save();
    }
}