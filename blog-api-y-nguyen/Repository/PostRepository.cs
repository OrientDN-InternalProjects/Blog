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
        public bool CheckPostsExist()
        {
            return !(_context.Posts == null);
        }

        // GET all Posts:
        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts.ToList();
        }

        // GET a Post by Id:
        public Post GetPost(int id)
        {
            return _context.Posts.Find(id);
        }

        // PUT a Post
        public Post PutPost(Post post)
        {
            var postToBeUpdated = _context.Posts.Find(post.PostId);
            postToBeUpdated.PostId = post.PostId;
            postToBeUpdated.Title = post.Title;
            postToBeUpdated.Content = post.Content;
            postToBeUpdated.AuthorId = post.AuthorId;
            postToBeUpdated.BlogId = post.BlogId;
            postToBeUpdated.Author = post.Author;
            postToBeUpdated.Blog = post.Blog;
            //_context.Posts.Update(post);
            _context.SaveChanges();
            return postToBeUpdated;
        }

        // POST a Post:
        public Post PostPost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            return post;
        }

        // DELETE a Post:
        public Post DeletePost(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
            return post;
        }

        // Check Post Exists:
        public bool PostExists(int id)
        {
            return (_context.Posts?.Any(e => e.PostId == id)).GetValueOrDefault();
        }
    }
}
