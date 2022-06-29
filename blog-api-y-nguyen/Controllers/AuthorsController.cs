using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using blog_api_y_nguyen.Models;
using blog_api_y_nguyen.Repository;
using blog_api_y_nguyen.Services;

namespace blog_api_y_nguyen.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IAuthorService _authorService;
        public AuthorsController(BlogContext context)
        {
            _authorService = new AuthorService(context);
        }

        // GET: api/Authors
        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAllAuthors()
        {
            if (_authorService.CheckAuthorsExist() == false)
            {
                return NotFound();
            }
            return _authorService.GetAllAuthors();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthor(int id)
        {
            if (_authorService.CheckAuthorsExist() == false)
            {
                return NotFound();
            }
            var author = _authorService.GetAuthor(id);
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
            _authorService.PutAuthor(author);
            try
            {
                _authorService.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_authorService.AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

        // POST: api/Authors
        [HttpPost]
        public ActionResult<Author> PostAuthor(Author author)
        {
            if (_authorService.CheckAuthorsExist() == false)
            {
                return Problem("Entity set 'BlogContext.Authors'  is null.");
            }
            _authorService.PostAuthor(author);
            _authorService.Save();
            return CreatedAtAction(nameof(GetAuthor), new { id = author.AuthorId }, author);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            if (_authorService.CheckAuthorsExist() == false)
            {
                return NotFound();
            }
            var authorDel = _authorService.GetAuthor(id);
            if (authorDel == null)
            {
                return NotFound();
            }
            _authorService.DeleteAuthor(authorDel);
            _authorService.Save();
            return Ok();
        }
    }
}
