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
    public class PostRepositoryTests
    {
        private DbContextOptions<BlogContext> dbContextOptions;
        private readonly PostRepository _postRepository;
        public PostRepositoryTests()
        {
            var dbName = $"PostPostsDb_{DateTime.Now.ToFileTimeUtc()}";
            dbContextOptions = new DbContextOptionsBuilder<BlogContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        [Fact]
        public void GetAllPosts_Success_Test()
        {
            var repository = CreateRepository();

            // Act
            var postList = repository.GetAllPosts();

            // Assert
            Assert.Equal(3, postList.Count());
        }

        [Fact]
        public void GetPost_Success_Test()
        {
            var repository = CreateRepository();

            // Act
            var post = repository.GetPost(2);

            // Assert
            Assert.Equal("Title_2", post.Title);
        }

        [Fact]
        public void PostPost_Success_Test()
        {
            var repository = CreateRepository();

            // Act
            var post = new Post()
            {
                PostId = 4,
                Title = "Title_4",
                Content = "Content_4",
                BlogId = 4,
                AuthorId = 4
            };
            repository.PostPost(post);

            // Assert
            var postList = repository.GetAllPosts();
            Assert.Equal(4, postList.Count());
            Assert.True(postList.Contains(post));
        }

        [Fact]
        public void DeletePost_Success_Test()
        {
            var repository = CreateRepository();

            // Act
            var post = repository.GetPost(3);
            repository.DeletePost(post);

            // Assert 
            var postList = repository.GetAllPosts();
            Assert.Equal(2, postList.Count());
            Assert.True(!postList.Contains(post));
        }

        [Fact]
        public void PutPost_Success_Test()
        {
            var repository = CreateRepository();

            // Act
            var editedPost = new Post()
            {
                PostId = 2,
                Title = "Title_2",
                Content = "Content_2",
                BlogId = 2,
                AuthorId = 2
            };
            repository.PutPost(editedPost);

            // Assert
            Assert.Equal(2, repository.GetPost(2).AuthorId);
        }

        public PostRepository CreateRepository()
        {
            BlogContext context = new BlogContext(dbContextOptions);
            PopulateDataAsync(context);
            return new PostRepository(context);
        }
        public async Task PopulateDataAsync(BlogContext context)
        {
            int index = 1;

            while (index <= 3)
            {
                var post = new Post()
                {
                    PostId = index,
                    Title = $"Title_{index}",
                    Content = $"Content_{index}",
                    BlogId = index,
                    AuthorId = index
                };
                index++;
                await context.Posts.AddAsync(post);
            }
            await context.SaveChangesAsync();
        }
    }
}
