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
    public class AuthorsController : ControllerBase
    {
        private IAuthorRepository _authorRepository;
        public AuthorsController(BlogContext context)
        {
            _authorRepository = new AuthorRepository(context);
        }

        // GET: api/Authors
        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAllAuthors()
        {
            if ( _authorRepository.CheckAuthorsIsNull() )
            {
                return NotFound();
            }
            return _authorRepository.GetAllAuthors();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthor(int id)
        {
            if (_authorRepository.CheckAuthorsIsNull())
            {
                return NotFound();
            }
            var author = _authorRepository.GetAuthor(id);
            if ( author == null)
            {
                return NotFound();
            }
            return author;
        }

        // PUT: api/Authors/5
        [HttpPut("{id}")]
        public IActionResult PutAuthor(int id, Author author)
        {
            if (id != author.AuthorId)
            {
               return BadRequest();
            }
            _authorRepository.PutAuthor(author);
            try
            {
                _authorRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_authorRepository.AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/Authors
        [HttpPost]
        public ActionResult<Author> PostBlog(Author author)
        {
            if (_authorRepository.CheckAuthorsIsNull())
            {
                return Problem("Entity set 'BlogContext.Authors'  is null.");
            }
            _authorRepository.PostAuthor(author);
            _authorRepository.Save();
            return CreatedAtAction(nameof(GetAuthor), new { id = author.AuthorId }, author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            if (_authorRepository.CheckAuthorsIsNull())
            {
                return NotFound();
            }
            var authorDel = _authorRepository.GetAuthor(id);
            if (authorDel == null)
            {
                return NotFound();
            }
            _authorRepository.DeleteAuthor(authorDel);
            _authorRepository.Save();
            return NoContent();
        }
    }
}
