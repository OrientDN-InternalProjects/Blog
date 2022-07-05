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
    public class BlogServiceTests
    {
        private readonly BlogService _blogService;
        private readonly Mock<IBlogRepository> _blogRepoMock = new Mock<IBlogRepository>();
        public BlogServiceTests()
        {
            _blogService = new BlogService(_blogRepoMock.Object);
        }

        [Fact]
        public void GetAllBlogs_Success_Test()
        {
            // ABlog
            List<Blog> blogs = new List<Blog>();
            var blogDto_1 = new Blog { BlogId = 1, Name = "blogDto_1", Url = "1.com" };
            var blogDto_2 = new Blog { BlogId = 2, Name = "blogDto_2", Url = "2.com" };
            var blogDto_3 = new Blog { BlogId = 3, Name = "blogDto_3", Url = "3.com" };
            blogs.Add(blogDto_1);
            blogs.Add(blogDto_2);
            blogs.Add(blogDto_3);
            _blogRepoMock.Setup(x => x.GetAllBlogs()).Returns(blogs);

            // Act
            var blogList = _blogService.GetAllBlogs();

            // Assert
            Assert.Equal(3, blogList.Count());
        }

        [Fact]
        public void GetBlog_Success_Test()
        {
            // Arrange
            var BlogId = 2;
            var Name = "Blog_2";
            var Url = "2.com";
            var blogDto = new Blog { BlogId = BlogId, Name = Name, Url = Url };
            _blogRepoMock.Setup(x => x.GetBlog(BlogId)).Returns(blogDto);

            // Act
            var blog = _blogService.GetBlog(2);

            // Assert
            Assert.Equal("Blog_2", blog.Name);
        }

        [Fact]
        public void PostBlog_Success_Test()
        {
            // Arrange
            var BlogId = 4;
            var Name = "Blog_4";
            var Url = "4.com";
            var blogDto = new Blog { BlogId = BlogId, Name = Name, Url = Url };
            _blogRepoMock.Setup(x => x.PostBlog(blogDto)).Returns(blogDto);

            // Act
            _blogService.PostBlog(blogDto);

            // Assert
            Assert.Equal("4.com", blogDto.Url);
        }

        [Fact]
        public void PutBlog_Success_Test()
        {
            // Arrange
            var BlogId = 2;
            var Name = "Blog_2.2";
            var Url = "2.com";
            var blogDto = new Blog { BlogId = BlogId, Name = Name, Url = Url };
            _blogRepoMock.Setup(x => x.PutBlog(blogDto)).Returns(blogDto);

            // Act
            _blogService.PutBlog(blogDto);

            // Assert
            Assert.Equal("Blog_2.2", blogDto.Name);
        }

        [Fact]
        public void DeleteBlog_Success_Test()
        {
            // Arrange
            var BlogId = 1;
            var Name = "Blog_1";
            var Url = "1.com";
            var blogDto = new Blog { BlogId = BlogId, Name = Name, Url = Url };
            _blogRepoMock.Setup(x => x.PutBlog(blogDto)).Returns(blogDto);

            // Act
            _blogService.DeleteBlog(blogDto);

            // Assert
            Assert.Equal("Blog_1", blogDto.Name);
        }
    }
}
