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
        private readonly Mock<INewsFeedRepository> _mockService;
        private readonly NewsFeedController _controller;

        public UsersControllerTests()
        {
            _mockService = new Mock<INewsFeedRepository>();
            _controller = new NewsFeedController(_mockService.Object);
        }

        [Fact]
        public void GetUsers_ReturnsOkResult_WithListOfUsers()
        {
            // Arrange
            var item = new Items
            {
                By = "pg",
                Id = 160705,
                Poll = 160704,
                Score = 335,
                Text = "Yes, ban them; I'm tired of seeing Valleywag stories on News.YC.",
                Time = 1207886576,
                Type = "pollopt"
            };
                        
            _mockService.Setup(s => s.GetItemByIdAsync(160705)).ReturnsAsync(item);

            // Act
            var result = _controller.GetItemByIdAsync(160705);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnUsers = Assert.IsType<Items>(okResult.Value);
            Assert.Single<Items>((IAsyncEnumerable<Items>)returnUsers);
        }

      
    }

}
