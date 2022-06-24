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

        // Get all Author:
        public IEnumerable<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }

        // Get a Author by Id:
        public Author GetAuthor(int id)
        {
            return _context.Authors.Find(id);
        }

        // Put a Author:
        public void PutAuthor(Author author)
        {
            _context.Authors.Update(author);
        }

        //Post a Author:
        public void PostAuthor(Author author)
        {
            _context.Authors.Add(author);
        }

        // Delete a Author:
        public void DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
