using Xunit;
using Moq;
using System.Collections.Generic;
using HackerNewsFeed.Controllers;
using HackerNewsFeed.Models;
using HackerNewsFeed.Contracts;
using HackerNewsFeed.Provider;
using Microsoft.AspNetCore.Mvc;
namespace HackerAPITest.Tests
{
  

    public class UsersControllerTests
    {
        private readonly Mock<IUserRepository> _mockService;
        private readonly UserController _controller;

        public UsersControllerTests()
        {
            _mockService = new Mock<IUserRepository>();
            _controller = new UserController(_mockService.Object);
        }

        [Fact]
        public void GetUsers_ReturnsOkResult_WithListOfUsers()
        {
            // Arrange
            var users = new List<Users>
        {
            new Users { Id = "user1", Karma = 100, About = "Test user" }
        };
            _mockService.Setup(s => s.GetUsersAsync()).Returns((Task<IEnumerable<Users>>)users.AsEnumerable());

            // Act
            var result = _controller.GetUsers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnUsers = Assert.IsType<List<Users>>(okResult.Value);
            Assert.Single(returnUsers);
        }

        [Fact]
        public void AddUser_ReturnsOkResult()
        {
            // Arrange
            var user = new Users { Id = "newuser", Karma = 50, About = "New user" };

            // Act
            var result = _controller.CreateUser(user);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnUser = Assert.IsType<Users>(okResult.Value);
            Assert.Equal("newuser", returnUser.Id);
        }
    }

}
