using blog_api_y_nguyen.Models;
using Microsoft.AspNetCore.Mvc;

namespace blog_api_y_nguyen.Repository
{
    public interface IAuthorRepository
    {
        bool CheckAuthorsExist();
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthor(int id);
        Author PutAuthor(Author author);
        Author PostAuthor(Author author);
        Author DeleteAuthor(Author author);
        bool AuthorExists(int id);
    }
}