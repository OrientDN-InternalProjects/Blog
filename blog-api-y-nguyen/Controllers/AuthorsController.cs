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
using AutoMapper;

namespace blog_api_y_nguyen.Controllers
{
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _autoMapper;
        public AuthorsController(IMapper autoMapper, IAuthorService authorService)
        {
            _autoMapper = autoMapper;
            _authorService = authorService;
        }

        // GET: api/Authors
        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAllAuthors()
        {
            if (_authorService.CheckAuthorsExist() == false)
            {
                return NotFound();
            }
            return Ok(_authorService.GetAllAuthors());
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
            if (!_authorService.AuthorExists(id))
            {
                return NotFound();
            }
            else
            {
                _authorService.PutAuthor(author);
                return Ok();
            }
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
            var AuthorToBeDeleted = _authorService.GetAuthor(id);
            if (AuthorToBeDeleted == null)
            {
                return NotFound();
            }
            _authorService.DeleteAuthor(AuthorToBeDeleted);
            return Ok();
        }
    }
}
