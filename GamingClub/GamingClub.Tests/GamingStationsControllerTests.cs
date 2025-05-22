using GamingClub.Domain.Entities;
using GamingClub.Domain.Interfaces;
using GamingClub.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace GamingClub.Tests
{
    public class GamingStationsControllerTests
    {
        private readonly Mock<IGamingStationRepository> _mockRepo;
        private readonly GamingStationsController _controller;

        public GamingStationsControllerTests()
        {
            _mockRepo = new Mock<IGamingStationRepository>();
            _controller = new GamingStationsController(_mockRepo.Object);
        }

        [Fact]
        public async Task GetGamingStationsAsync_ReturnsOkResultWithStations()
        {
            // Arrange
            var testStations = new List<GamingStationEntity>
            {
                new GamingStationEntity { Id = 1, Type = GamingStationType.PC},
                new GamingStationEntity { Id = 2, Type = GamingStationType.VR}
            };

            _mockRepo.Setup(repo => repo.GetGamingStationsAsync())
                .ReturnsAsync(testStations);

            // Act
            var result = await _controller.GetGamingStationsAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedStations = Assert.IsType<List<GamingStationEntity>>(okResult.Value);
            Assert.Equal(2, returnedStations.Count);
        }

        [Fact]
        public async Task GetGamingStationsAsync_ReturnsEmptyList_WhenNoStationsExist()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetGamingStationsAsync())
                .ReturnsAsync(new List<GamingStationEntity>());

            // Act
            var result = await _controller.GetGamingStationsAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedStations = Assert.IsType<List<GamingStationEntity>>(okResult.Value);
            Assert.Empty(returnedStations);
        }
    }
}