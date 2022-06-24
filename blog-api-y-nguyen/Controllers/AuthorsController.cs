using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using blog_api_y_nguyen.Models;
using blog_api_y_nguyen.Repository;

namespace blog_api_y_nguyen.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : Controller
    {
        private IAuthorRepository _authorRepository;
        private readonly BlogContext _context;
        public AuthorsController(BlogContext context)
        {
            _context = context;
            _authorRepository = new AuthorRepository(_context);
        }

        // GET: api/Authors
        [HttpGet]
        public IEnumerable<Author> GetAllAuthors()
        {
            return _authorRepository.GetAllAuthors();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public Author GetAuthor(int id)
        {
            return _authorRepository.GetAuthor(id);
        }

        // PUT: api/Authors/5
        [HttpPut]
        public void PutAuthor(Author Author)
        {
            _authorRepository.PutAuthor(Author);
            _authorRepository.Save();
        }

        // POST: api/Authors
        [HttpPost]
        public void PostBlog(Author author)
        {
            _authorRepository.PostAuthor(author);
            _authorRepository.Save();
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public void DeleteAuthor(Author author)
        {
            _authorRepository.DeleteAuthor(author);
            _authorRepository.Save();
        }
    }
}
