using GamingClub.Application.DTOs.User;
using GamingClub.Application.Interfaces;
using GamingClub.Server.Controllers;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace GamingClub.Tests
{
    public class UsersControllerTests
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<IValidator<UserDTO>> _mockValidator;
        private readonly UsersController _controller;

        public UsersControllerTests()
        {
            _mockUserService = new Mock<IUserService>();
            _mockValidator = new Mock<IValidator<UserDTO>>();
            _controller = new UsersController(_mockValidator.Object, _mockUserService.Object);
        }

        [Fact]
        public async Task GetUserById_ReturnsOkResult_WhenUserExists()
        {
            // Arrange
            var testUser = new UserDTO { Id = 1, Username = "testuser", Email = "test@example.com" };
            _mockUserService.Setup(s => s.GetUserByIdAsync(1)).ReturnsAsync(testUser);

            // Act
            var result = await _controller.GetUserById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUser = Assert.IsType<UserDTO>(okResult.Value);
            Assert.Equal(testUser.Id, returnedUser.Id);
        }

        [Fact]
        public async Task GetUserById_ReturnsNotFound_WhenUserDoesNotExist()
        {
            // Arrange
            _mockUserService.Setup(s => s.GetUserByIdAsync(It.IsAny<int>())).ReturnsAsync((UserDTO)null);

            // Act
            var result = await _controller.GetUserById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetUserWithReservations_ReturnsOkResult_WhenUserExists()
        {
            // Arrange
            var testUser = new UserWithReservationsDTO { Id = 1 };
            _mockUserService.Setup(s => s.GetUserWithReservationsByIdAsync(1)).ReturnsAsync(testUser);

            // Act
            var result = await _controller.GetUserWithReservations(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUser = Assert.IsType<UserWithReservationsDTO>(okResult.Value);
            Assert.Equal(testUser.Id, returnedUser.Id);
        }

        [Fact]
        public async Task CreateUser_ReturnsOkResult_WhenModelIsValid()
        {
            // Arrange
            var userDTO = new UserDTO { Username = "newuser", Email = "new@example.com" };
            var validationResult = new FluentValidation.Results.ValidationResult();
            _mockValidator.Setup(v => v.ValidateAsync(userDTO, default)).ReturnsAsync(validationResult);
            _mockUserService.Setup(s => s.CreateUserAsync(userDTO)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.CreateUser(userDTO);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdateUser_ReturnsOkResult_WhenSuccessful()
        {
            // Arrange
            var userUpdateDTO = new UserUpdateDTO();
            _mockUserService.Setup(s => s.UpdateUserAsync(userUpdateDTO, 1)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.UpdateUser(userUpdateDTO, 1);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteUser_ReturnsOkResult_WhenSuccessful()
        {
            // Arrange
            _mockUserService.Setup(s => s.DeleteUserByIdAsync(1)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteUser(1);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}