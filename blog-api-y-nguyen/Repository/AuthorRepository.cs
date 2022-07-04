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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BlogContext _context;
        public AuthorRepository (BlogContext context)
        {
            _context = context;
        }

        // Check whether Authors is null or not:
        public bool CheckAuthorsExist()
        {
            return !(_context.Authors == null);
        }

        // GET all Author:
        public IEnumerable<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }

        // GET an Author by Id:
        public Author GetAuthor(int id)
        {
            var author = _context.Authors.Find(id);
            //_context.Entry(author).State = EntityState.Detached;
            //return _context.Authors.Where(a => a.AuthorId == id).AsNoTracking();
            return author;
        }

        // PUT an Author:
        public Author PutAuthor(Author author)
        {
            var entry = _context.Entry(author);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
            //_context.Authors.Update(author);
            //_context.SaveChanges();
            return author;
        }

        // POST an Author:
        public Author PostAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author;
        }

        // DELETE an Author:
        public Author DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
            return author;
        }

        // Check Author Exists:
        public bool AuthorExists(int id)
        {
            return (_context.Authors?.Any(e => e.AuthorId == id)).GetValueOrDefault();
        }
    }
}
