//using blog_api_y_nguyen.Models;
//using blog_api_y_nguyen.Repository;
//using blog_api_y_nguyen.Services;
//using Microsoft.EntityFrameworkCore;
//using Moq;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;
//using Assert = Xunit.Assert;

//namespace TestProject1
//{
//    public class AuthorServiceTests
//    {
//        private DbContextOptions<BlogContext> dbContextOptions;
//        private readonly AuthorService _authorService;
//        public AuthorServiceTests()
//        {
//            var dbName = $"AuthorPostsDb_{DateTime.Now.ToFileTimeUtc()}";
//            dbContextOptions = new DbContextOptionsBuilder<BlogContext>()
//                .UseInMemoryDatabase(dbName)
//                .Options;
//        }

//        [Fact]
//        public void GetAllAuthors_Success_Test()
//        {
//            var service = CreateService();

//            // Act
//            var authorList = service.GetAllAuthors();
//            Assert.Equal(3, authorList.Count());
//        }

//        [Fact]
//        public void GetAuthor_Success_Test()
//        {
//            var service = CreateService();

//            // Act
//            var author = service.GetAuthor(2);

//            // Assert
//            Assert.Equal("Author_2", author.Name);
//        }
//        //public AuthorService CreateService()
//        //{
//        //    BlogContext context = new BlogContext(dbContextOptions);
//        //    PopulateDataAsync(context);
//        //    return new AuthorService(context);
//        //}
//        public async Task PopulateDataAsync(BlogContext context)
//        {
//            int index = 1;

//            while (index <= 3)
//            {
//                var author = new Author()
//                {
//                    AuthorId = index,
//                    Name = $"Author_{index}",
//                    Age = index
//                };
//                index++;
//                await context.Authors.AddAsync(author);
//            }

//            await context.SaveChangesAsync();
//        }
//    }
//}
