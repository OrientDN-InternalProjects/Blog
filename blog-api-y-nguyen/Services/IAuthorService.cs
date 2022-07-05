using blog_api_y_nguyen.Models;
using Microsoft.AspNetCore.Mvc;

namespace blog_api_y_nguyen.Services
{
    public interface IAuthorService
    {
        bool CheckAuthorsExist();
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthor(int id);
        void PutAuthor(Author author);
        void PostAuthor(Author author);
        void DeleteAuthor(Author author);
        bool AuthorExists(int id);
    }
}