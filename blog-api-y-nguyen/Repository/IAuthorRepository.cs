using blog_api_y_nguyen.Models;
namespace blog_api_y_nguyen.Repository
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthor(int id);
        void PutAuthor(Author author);
        void PostAuthor(Author author);
        void DeleteAuthor(Author author);
        void Save();
    }
}