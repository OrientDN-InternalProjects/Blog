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
    public class BlogRepositoryTests
    {
        private DbContextOptions<BlogContext> dbContextOptions;
        private readonly BlogRepository _blogRepository;
        public BlogRepositoryTests()
        {
            var dbName = $"BlogPostsDb_{DateTime.Now.ToFileTimeUtc()}";
            dbContextOptions = new DbContextOptionsBuilder<BlogContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        [Fact]
        public void GetAllBlogs_Success_Test()
        {
            var repository = CreateRepository();

            // Act
            var blogList = repository.GetAllBlogs();

            // Assert
            Assert.Equal(3, blogList.Count());
        }

        [Fact]
        public void GetBlog_Success_Test()
        {
            var repository = CreateRepository();

            // Act
            var blog = repository.GetBlog(2);

            // Assert
            Assert.Equal("Blog_2", blog.Name);
        }

        [Fact]
        public void PostBlog_Success_Test()
        {
            var repository = CreateRepository();

            // Act
            var blog = new Blog()
            {
                BlogId = 4,
                Name = "Blog_4",
                Url = "4.com"
            };
            repository.PostBlog(blog);

            // Assert
            var blogList = repository.GetAllBlogs();
            Assert.Equal(4, blogList.Count());
            Assert.True(blogList.Contains(blog));
        }

        [Fact]
        public void DeleteBlog_Success_Test()
        {
            var repository = CreateRepository();

            // Act
            var blog = repository.GetBlog(3);
            repository.DeleteBlog(blog);

            // Assert 
            var blogList = repository.GetAllBlogs();
            Assert.Equal(2, blogList.Count());
            Assert.True(!blogList.Contains(blog));
        }

        [Fact]
        public void PutBlog_Success_Test()
        {
            var repository = CreateRepository();

            // Act
            var editedBlog = new Blog()
            {
                BlogId = 2,
                Name = "Blog_2.2",
                Url = "2.com"
            };
            repository.PutBlog(editedBlog);

            // Assert
            Assert.Equal("Blog_2.2", repository.GetBlog(2).Name);
        }

        public BlogRepository CreateRepository()
        {
            BlogContext context = new BlogContext(dbContextOptions);
            PopulateDataAsync(context);
            return new BlogRepository(context);
        }
        public async Task PopulateDataAsync(BlogContext context)
        {
            int index = 1;

            while (index <= 3)
            {
                var blog = new Blog()
                {
                    BlogId = index,
                    Name = $"Blog_{index}",
                    Url = $"{index}.com"
                };
                index++;
                await context.Blogs.AddAsync(blog);
            }
            await context.SaveChangesAsync();
        }
    }
}
