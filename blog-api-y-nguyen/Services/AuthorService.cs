using blog_api_y_nguyen.Models;
using blog_api_y_nguyen.Repository;
using Microsoft.AspNetCore.Mvc;

namespace blog_api_y_nguyen.Services
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository _authorRepository;
        public AuthorService(BlogContext context)
        {
            _authorRepository = new AuthorRepository(context);
        }

        // Check whether Authors is exist or not:
        public bool CheckAuthorsExist()
        {
            return _authorRepository.CheckAuthorsExist();
        }

        // GET: api/Authors
        public IEnumerable<Author> GetAllAuthors()
        {
            return _authorRepository.GetAllAuthors();
        }

        // GET: api/Authors/5
        public Author GetAuthor(int id)
        {
            return _authorRepository.GetAuthor(id);
        }

        // PUT: api/Authors/5
        public void PutAuthor(Author author)
        {
            _authorRepository.PutAuthor(author);
        }

        // POST: api/Authors
        public void PostAuthor(Author author)
        {
            _authorRepository.PostAuthor(author);
        }

        // DELETE: api/Authors/5
        public void DeleteAuthor(Author author)
        {
            _authorRepository.DeleteAuthor(author);
        }

        // Check Author Exists:
        public bool AuthorExists(int id)
        {
            return _authorRepository.AuthorExists(id);
        }
    }
}
