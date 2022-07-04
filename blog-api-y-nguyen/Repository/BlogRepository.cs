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
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext _context;
        public BlogRepository(BlogContext context)
        {
            _context = context;
        }

        // Check whether Blogs is null or not:
        public bool CheckBlogsExist()
        {
            return !(_context.Blogs == null);
        }

        // GET all Blogs: 
        public IEnumerable<Blog> GetAllBlogs()
        {
            return _context.Blogs.ToList();
        }

        // GET a Blog by Id:
        public Blog GetBlog(int id)
        {
            return _context.Blogs.Find(id);
        }

        // PUT a Blog
        public void PutBlog(Blog blog)
        {
            _context.Blogs.Update(blog);
            _context.SaveChanges();
        }

        // POST a Blog:
        public void PostBlog(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();
        }

        // DELETE a Blog:
        public void DeleteBlog(Blog blog)
        {
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
        }
       
        // Check Blog Exists:
        public bool BlogExists(int id)
        {
            return (_context.Blogs?.Any(e => e.BlogId == id)).GetValueOrDefault();
        }
    }
}
