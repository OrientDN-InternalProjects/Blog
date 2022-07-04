using blog_api_y_nguyen.Models;
using blog_api_y_nguyen.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1
{
    public class AuthorRepositoryTests
    {
        private DbContextOptions<BlogContext> dbContextOptions;
        private readonly AuthorRepository _authorRepository;
        public AuthorRepositoryTests()
        {
            var dbName = $"AuthorPostsDb_{DateTime.Now.ToFileTimeUtc()}";
            dbContextOptions = new DbContextOptionsBuilder<BlogContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }
 
        [Fact]
        public void GetAllAuthors_Success_Test()
        {
            var repository =  CreateRepository();

            // Act
            var authorList = repository.GetAllAuthors();
            
            // Assert
            Assert.Equal(3, authorList.Count());
        }

        [Fact]
        public void GetAuthor_Success_Test()
        {
            var repository = CreateRepository();

            // Act
            var author = repository.GetAuthor(2);

            // Assert
            Assert.Equal("Author_2", author.Name);
        }

        [Fact]
        public void PostAuthor_Success_Test()
        {
            var repository = CreateRepository();

            // Act
            var author = new Author()
            {
                AuthorId = 4,
                Name = "Peter Taylor",
                Age = 33
            };
            repository.PostAuthor(author);
            
            // Assert
            var authorList = repository.GetAllAuthors();
            Assert.Equal(4, authorList.Count());
            Assert.True(authorList.Contains(author));
        }

        [Fact]
        public void DeleteAuthor_Success_Test()
        {
            var repository = CreateRepository();

            // Act
            var author = repository.GetAuthor(3);
            repository.DeleteAuthor(author);

            // Assert 
            var authorList = repository.GetAllAuthors();
            Assert.Equal(2, authorList.Count());
            Assert.True(!authorList.Contains(author));
        }

        [Fact]
        public void PutAuthor_Success_Test()
        {
            var repository = CreateRepository();

            // Act
            var editedAuthor = new Author()
            {
                AuthorId = 2,
                Name = "Taylor Swift",
                Age = 33
            };
            repository.PutAuthor(editedAuthor);

            // Assert
            Assert.Equal("Taylor Swift", repository.GetAuthor(2).Name);
        }

        public AuthorRepository CreateRepository()
        {
            BlogContext context = new BlogContext(dbContextOptions);
            PopulateDataAsync(context);
            return new AuthorRepository(context);
        }
        public async Task PopulateDataAsync(BlogContext context)
        {
            int index = 1;

            while (index <= 3)
            {
                var author = new Author()
                {
                    AuthorId = index,
                    Name = $"Author_{index}",
                    Age = index
                };
                index++;
                await context.Authors.AddAsync(author);
            }

            await context.SaveChangesAsync();
        }
    }
}
