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
    public class blogRepository : IAuthorRepository
    {
        private readonly BlogContext _context;
        public blogRepository (BlogContext context)
        {
            _context = context;
        }

        // Check whether Authors is null or not:
        public bool CheckAuthorsExist()
        {
            if (_context.Authors == null) return false;
            return true;
        }

        // GET all Author:
        public ActionResult<IEnumerable<Blog>> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }

        // GET an Author by Id:
        public Blog GetAuthor(int id)
        {
            return _context.Authors.Find(id);
        }

        // PUT an Author:
        public void PutAuthor(Blog author)
        {
             _context.Authors.Update(author);
        }

        // POST an Author:
        public void PostAuthor(Blog author)
        {
            _context.Authors.Add(author);
        }

        // DELETE an Author:
        public void DeleteAuthor(Blog author)
        {
            _context.Authors.Remove(author);
        }

        // Save Change:
        public void Save()
        {
            _context.SaveChanges();
        }

        // Check Author Exists:
        public bool AuthorExists(int id)
        {
            return (_context.Authors?.Any(e => e.AuthorId == id)).GetValueOrDefault();
        }
    }
}
