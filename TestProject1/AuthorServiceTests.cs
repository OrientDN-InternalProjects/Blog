using blog_api_y_nguyen.Models;
using blog_api_y_nguyen.Repository;
using blog_api_y_nguyen.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Assert = Xunit.Assert;

namespace TestProject1
{
    public class AuthorServiceTests
    {
        private readonly AuthorService _authorService;
        private readonly Mock<IAuthorRepository> _authorRepoMock = new Mock<IAuthorRepository>();
        public AuthorServiceTests()
        {
            _authorService = new AuthorService(_authorRepoMock.Object);
        }

        [Fact]
        public void GetAllAuthors_Success_Test()
        {
            // Arrange
            List<Author> authors = new List<Author>();
            var authorDto_1 = new Author { AuthorId = 1, Name = "authorDto_1", Age = 1 };
            var authorDto_2 = new Author { AuthorId = 2, Name = "authorDto_2", Age = 2 };
            var authorDto_3 = new Author { AuthorId = 3, Name = "authorDto_3", Age = 3 };
            authors.Add(authorDto_1);
            authors.Add(authorDto_2);
            authors.Add(authorDto_3);
            _authorRepoMock.Setup(x => x.GetAllAuthors()).Returns(authors);

            // Act
            var authorList = _authorService.GetAllAuthors();

            // Assert
            Assert.Equal(3, authorList.Count());
        }

        [Fact]
        public void GetAuthor_Success_Test()
        {
            // Arrange
            var AuthorId = 2;
            var Name = "Peter";
            var Age = 24;
            var authorDto = new Author { AuthorId = AuthorId, Name = Name, Age = Age };
            _authorRepoMock.Setup(x => x.GetAuthor(AuthorId)).Returns(authorDto);

            // Act
            var author = _authorService.GetAuthor(2);

            // Assert
            Assert.Equal("Peter", author.Name);
        }

        [Fact]
        public void PostAuthor_Success_Test()
        {
            // Arrange
            var AuthorId = 4;
            var Name = "Author_4";
            var Age = 4;
            var authorDto = new Author { AuthorId = AuthorId, Name = Name, Age = Age };
            _authorRepoMock.Setup(x => x.PostAuthor(authorDto)).Returns(authorDto);

            // Act
            _authorService.PostAuthor(authorDto);

            // Assert
            Assert.Equal(4, authorDto.Age);
        }

        [Fact]
        public void PutAuthor_Success_Test()
        {
            // Arrange
            var AuthorId = 2;
            var Name = "Author_2.2";
            var Age = 2;
            var authorDto = new Author { AuthorId = AuthorId, Name = Name, Age = Age };
            _authorRepoMock.Setup(x => x.PutAuthor(authorDto)).Returns(authorDto);

            // Act
            _authorService.PutAuthor(authorDto);

            // Assert
            Assert.Equal("Author_2.2", authorDto.Name);
        }

        [Fact]
        public void DeleteAuthor_Success_Test()
        {
            // Arrange
            var AuthorId = 1;
            var Name = "Author_1";
            var Age = 1;
            var authorDto = new Author { AuthorId = AuthorId, Name = Name, Age = Age };
            _authorRepoMock.Setup(x => x.PutAuthor(authorDto)).Returns(authorDto);

            // Act
            _authorService.DeleteAuthor(authorDto);

            // Assert
            Assert.Equal("Author_1", authorDto.Name);
        }
    }
}
