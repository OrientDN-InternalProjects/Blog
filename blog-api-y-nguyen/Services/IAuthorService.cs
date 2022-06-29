using blog_api_y_nguyen.Models;
using Microsoft.AspNetCore.Mvc;

namespace blog_api_y_nguyen.Services
{
    public interface IAuthorService
    {
        bool CheckAuthorsExist();
        ActionResult<IEnumerable<Blog>> GetAllAuthors();
        Blog GetAuthor(int id);
        void PutAuthor(Blog author);
        void PostAuthor(Blog author);
        void DeleteAuthor(Blog author);
        void Save();
        bool AuthorExists(int id);
    }
}