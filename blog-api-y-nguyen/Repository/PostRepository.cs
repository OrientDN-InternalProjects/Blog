using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using blog_api_y_nguyen.Models;
namespace blog_api_y_nguyen.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogContext _context;
        public PostRepository(BlogContext context)
        {
            _context = context;
        }

        // Check whether Posts is null or not:
        public bool CheckPostsIsNull()
        {
            if (_context.Posts == null) return true;
            return false;
        }

        // GET all Posts:
        public ActionResult<IEnumerable<Post>> GetAllPosts()
        {
            return _context.Posts.ToList();
        }

        // GET a Post by Id:
        public Post GetPost(int id)
        {
            return _context.Posts.Find(id);
        }

        // PUT a Post
        public void PutPost(Post post)
        {
            _context.Posts.Update(post);
        }

        // POST a Post:
        public void PostPost(Post post)
        {
            _context.Posts.Add(post);
        }

        // DELETE a Post:
        public void DeletePost(Post post)
        {
            _context.Posts.Remove(post);
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        // Check Post Exists:
        public bool PostExists(int id)
        {
            return (_context.Posts?.Any(e => e.PostId == id)).GetValueOrDefault();
        }
    }
}
