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
    public class PostServiceTests
    {
        private readonly PostService _postService;
        private readonly Mock<IPostRepository> _postRepoMock = new Mock<IPostRepository>();
        public PostServiceTests()
        {
            _postService = new PostService(_postRepoMock.Object);
        }

        [Fact]
        public void GetAllPosts_Success_Test()
        {
            // Arrange
            List<Post> posts = new List<Post>();
            var postDto_1 = new Post { PostId = 1, Title = "Title_1", Content = "Content_1", BlogId = 1, AuthorId = 1};
            var postDto_2 = new Post { PostId = 2, Title = "Title_2", Content = "Content_2", BlogId = 2, AuthorId = 2 };
            var postDto_3 = new Post { PostId = 3, Title = "Title_2", Content = "Content_3", BlogId = 3, AuthorId = 3 };
            posts.Add(postDto_1);
            posts.Add(postDto_2);
            posts.Add(postDto_3);
            _postRepoMock.Setup(x => x.GetAllPosts()).Returns(posts);

            // Act
            var postList = _postService.GetAllPosts();

            // Assert
            Assert.Equal(3, postList.Count());
        }

        [Fact]
        public void GetPost_Success_Test()
        {
            // Arrange
            var PostId = 2;
            var Title = "Title_2";
            var Content = "Content_2";
            var BlogId = 2;
            var AuthorId = 2;
            var postDto = new Post { PostId = PostId, Title = Title, Content = Content, BlogId = BlogId, AuthorId = AuthorId};
            _postRepoMock.Setup(x => x.GetPost(PostId)).Returns(postDto);

            // Act
            var post = _postService.GetPost(2);

            // Assert
            Assert.Equal("Title_2", post.Title);
        }

        [Fact]
        public void PostPost_Success_Test()
        {
            // Arrange
            var PostId = 4;
            var Title = "Title_4";
            var Content = "Content_4";
            var BlogId = 4;
            var AuthorId = 4;
            var postDto = new Post { PostId = PostId, Title = Title, Content = Content, BlogId = BlogId, AuthorId = AuthorId };
            _postRepoMock.Setup(x => x.PostPost(postDto)).Returns(postDto);

            // Act
            _postService.PostPost(postDto);

            // Assert
            Assert.Equal("Content_4", postDto.Content);
        }

        [Fact]
        public void PutPost_Success_Test()
        {
            // Arrange
            var PostId = 2;
            var Title = "Title_2.2";
            var Content = "Content_2";
            var BlogId = 2;
            var AuthorId = 2;
            var postDto = new Post { PostId = PostId, Title = Title, Content = Content, BlogId = BlogId, AuthorId = AuthorId };
            _postRepoMock.Setup(x => x.PutPost(postDto)).Returns(postDto);

            // Act
            _postService.PutPost(postDto);

            // Assert
            Assert.Equal("Title_2.2", postDto.Title);
        }

        [Fact]
        public void DeletePost_Success_Test()
        {
            // Arrange
            var PostId = 1;
            var Title = "Title_1";
            var Content = "Content_1";
            var BlogId = 1;
            var AuthorId = 1;
            var postDto = new Post { PostId = PostId, Title = Title, Content = Content, BlogId = BlogId, AuthorId = AuthorId };
            _postRepoMock.Setup(x => x.PutPost(postDto)).Returns(postDto);

            // Act
            _postService.DeletePost(postDto);

            // Assert
            Assert.Equal("Title_1", postDto.Title);
        }
    }
}
