using GamingClub.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using GamingClub.Server.Controllers;
using GamingClub.Domain.Entities;
using GamingClub.Application.DTOs.User;

namespace GamingClub.Tests
{
    public class UsersControllerTests
    {
        //private readonly Mock<IUserRepository> _mockRepo;
        //private readonly UsersController _controller;

        //public UsersControllerTests()
        //{
        //    _mockRepo = new Mock<IUserRepository>();
        //    _controller = new UsersController(_mockRepo.Object);
        //}

        //[Fact]
        //public async Task GetUserByIdAsync_ReturnsOkResultWithUser_WhenUserExists()
        //{
        //    // Arrange
        //    var testUser = new UserEntity
        //    {
        //        Id = 1,
        //        Username = "testuser",
        //        Email = "test@example.com",
        //        Reservations = new List<ReservationEntity>
        //        {
        //            new ReservationEntity { Id = 1 }
        //        }
        //    };

        //    _mockRepo.Setup(repo => repo.GetUserByIdAsync(1))
        //        .ReturnsAsync(testUser);

        //    // Act
        //    var result = await _controller.GetUserByIdAsync(1);

        //    // Assert
        //    var okResult = Assert.IsType<OkObjectResult>(result);
        //    var returnedUser = Assert.IsType<UserWithReservationsDTO>(okResult.Value);

        //    Assert.Equal(testUser.Id, returnedUser.Id);
        //    Assert.Equal(testUser.Username, returnedUser.Username);
        //    Assert.Equal(testUser.Email, returnedUser.Email);
        //    Assert.Single(returnedUser.Reservations);
        //}

        //[Fact]
        //public async Task GetUserByIdAsync_ReturnsNotFound_WhenUserDoesNotExist()
        //{
        //    // Arrange
        //    _mockRepo.Setup(repo => repo.GetUserByIdAsync(It.IsAny<int>()))
        //        .ReturnsAsync((UserEntity)null);

        //    // Act
        //    var result = await _controller.GetUserByIdAsync(1);

        //    // Assert
        //    Assert.IsType<NotFoundResult>(result);
        //}

        //[Fact]
        //public async Task CreateUser_ReturnsOkResult_WhenModelIsValid()
        //{
        //    // Arrange
        //    var userDTO = new UserDTO
        //    {
        //        Username = "newuser",
        //        Email = "new@example.com"
        //    };

        //    _mockRepo.Setup(repo => repo.CreateUserAsync(It.IsAny<UserDTO>()))
        //        .Returns(Task.CompletedTask);

        //    // Act
        //    var result = await _controller.CreateUser(userDTO);

        //    // Assert
        //    Assert.IsType<OkResult>(result);
        //}

        //[Fact]
        //public async Task CreateUser_ReturnsBadRequest_WhenModelIsInvalid()
        //{
        //    // Arrange
        //    var userDTO = new UserDTO(); // Invalid as it lacks required fields
        //    _controller.ModelState.AddModelError("Username", "Required");

        //    // Act
        //    var result = await _controller.CreateUser(userDTO);

        //    // Assert
        //    Assert.IsType<BadRequestObjectResult>(result);
        //}

        //[Fact]
        //public async Task UpdateUser_ReturnsOkResult_WhenModelIsValid()
        //{
        //    // Arrange
        //    var userDTO = new UserDTO
        //    {
        //        Id = 1,
        //        Username = "updateduser",
        //        Email = "updated@example.com"
        //    };

        //    _mockRepo.Setup(repo => repo.UpdateUserAsync(It.IsAny<UserDTO>()))
        //        .Returns(Task.CompletedTask);

        //    // Act
        //    var result = await _controller.UpdateUser(userDTO);

        //    // Assert
        //    Assert.IsType<OkResult>(result);
        //}

        //[Fact]
        //public async Task UpdateUser_ReturnsBadRequest_WhenModelIsInvalid()
        //{
        //    // Arrange
        //    var userDTO = new UserDTO(); 
        //    _controller.ModelState.AddModelError("Username", "Required");

        //    // Act
        //    var result = await _controller.UpdateUser(userDTO);

        //    // Assert
        //    Assert.IsType<BadRequestObjectResult>(result);
        //}

        //[Fact]
        //public async Task DeleteUser_ReturnsOkResult_WhenUserExists()
        //{
        //    // Arrange
        //    _mockRepo.Setup(repo => repo.DeleteUserByIdAsync(It.IsAny<int>()))
        //        .Returns(Task.CompletedTask);

        //    // Act
        //    var result = await _controller.DeleteUser(1);

        //    // Assert
        //    Assert.IsType<OkResult>(result);
        //}
    }
}