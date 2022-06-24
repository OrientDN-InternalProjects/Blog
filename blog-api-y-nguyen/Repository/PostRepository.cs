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

        // Get all Posts:
        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts.ToList();
        }

        // Get a Post by Id:
        public Post GetPost(int id)
        {
            return _context.Posts.Find(id);
        }

        // Put a Post
        public void PutPost(Post post)
        {
            _context.Posts.Update(post);
        }

        //Post a Post:
        public void PostPost(Post post)
        {
            _context.Posts.Add(post);
        }

        // Delete a Post:
        public void DeletePost(Post post)
        {
            _context.Posts.Remove(post);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
