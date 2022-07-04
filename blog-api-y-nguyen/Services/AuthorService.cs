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
        public ActionResult<IEnumerable<Author>> GetAllAuthors()
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
            _authorRepository.Save();
        }

        // POST: api/Authors
        public void PostAuthor(Author author)
        {
            _authorRepository.PostAuthor(author);
            _authorRepository.Save();
        }

        // DELETE: api/Authors/5
        public void DeleteAuthor(Author author)
        {
            _authorRepository.DeleteAuthor(author);
            _authorRepository.Save();
        }

        // Save Change:
        public void Save()
        {
            _authorRepository.Save();
        }

        // Check Author Exists:
        public bool AuthorExists(int id)
        {
            return _authorRepository.AuthorExists(id);
        }
    }
}
