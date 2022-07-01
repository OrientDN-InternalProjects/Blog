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
            //var list = authorList as IEnumerable<Author>();
            //var listt = (ActionResult)result.Result

            //var model = authorList.Model;
            //var list = model as List<int>();
            //var count = list.Count;

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
                AuthorId = 7,
                Name = "Peter Taylor",
                Age = 33
            };
            repository.PostAuthor(author);

            // Assert
            Assert.Equal("Peter Taylor", repository.GetAuthor(7).Name);
        }

        [Fact]
        public void DeleteAuthor_Success_Test()
        {
            var repository = CreateRepository();

            // Act
            var author = repository.GetAuthor(2);
            repository.DeleteAuthor(author);

            // Assert 
            Assert.Equal(null, author);
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
