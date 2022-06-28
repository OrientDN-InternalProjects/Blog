using blog_api_y_nguyen.Models;
using Microsoft.AspNetCore.Mvc;

namespace blog_api_y_nguyen.Repository
{
    public interface IAuthorRepository
    {
        bool CheckAuthorsIsNull();
        ActionResult<IEnumerable<Author>> GetAllAuthors();
        Author GetAuthor(int id);
        void PutAuthor(Author author);
        void PostAuthor(Author author);
        void DeleteAuthor(Author author);
        void Save();
        bool AuthorExists(int id);
    }
}