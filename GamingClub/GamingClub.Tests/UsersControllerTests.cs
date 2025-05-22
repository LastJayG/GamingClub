//using GamingClub.Application.DTOs.User;
//using GamingClub.Application.Interfaces;
//using GamingClub.Server.Controllers;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using Xunit;

//namespace GamingClub.Tests
//{
//    public class UsersControllerTests
//    {
//        private readonly Mock<IUserService> _mockUserService;
//        private readonly UsersController _controller;

//        public UsersControllerTests()
//        {
//            _mockUserService = new Mock<IUserService>();
//            _controller = new UsersController(_mockUserService.Object);
//        }

//        [Fact]
//        public async Task GetUserById_ReturnsOkResult_WhenUserExists()
//        {
//            // Arrange
//            var testUser = new UserDTO { Id = 1, Username = "testuser", Email = "test@example.com" };
//            _mockUserService.Setup(s => s.GetUserByIdAsync(1)).ReturnsAsync(testUser);

//            // Act
//            var result = await _controller.GetUserById(1);

//            // Assert
//            var okResult = Assert.IsType<OkObjectResult>(result);
//            var returnedUser = Assert.IsType<UserDTO>(okResult.Value);
//            Assert.Equal(testUser.Id, returnedUser.Id);
//            Assert.Equal(testUser.Username, returnedUser.Username);
//            Assert.Equal(testUser.Email, returnedUser.Email);
//        }

//        [Fact]
//        public async Task GetUserById_ReturnsNotFound_WhenUserDoesNotExist()
//        {
//            // Arrange
//            _mockUserService.Setup(s => s.GetUserByIdAsync(It.IsAny<int>())).ReturnsAsync((UserDTO)null);

//            // Act
//            var result = await _controller.GetUserById(1);

//            // Assert
//            Assert.IsType<NotFoundResult>(result);
//        }

//        [Fact]
//        public async Task GetUserFromFile_ReturnsOkResult_WhenFileExists()
//        {
//            // Arrange
//            var testUser = new UserDTO { Id = 1, Username = "testuser", Email = "test@example.com" };
//            _mockUserService.Setup(s => s.GetUserFromFileAsync(1)).ReturnsAsync(testUser);

//            // Act
//            var result = await _controller.GetUserFromFile(1);

//            // Assert
//            var okResult = Assert.IsType<OkObjectResult>(result);
//            var returnedUser = Assert.IsType<UserDTO>(okResult.Value);
//            Assert.Equal(testUser.Id, returnedUser.Id);
//        }

//        [Fact]
//        public async Task GetUserFromFile_ReturnsNotFound_WhenFileDoesNotExist()
//        {
//            // Arrange
//            _mockUserService.Setup(s => s.GetUserFromFileAsync(It.IsAny<int>())).ReturnsAsync((UserDTO)null);

//            // Act
//            var result = await _controller.GetUserFromFile(1);

//            // Assert
//            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
//            Assert.Contains("not found", notFoundResult.Value.ToString());
//        }

//        [Fact]
//        public async Task CreateUser_ReturnsOkResult_WhenModelIsValid()
//        {
//            // Arrange
//            var userCreateDto = new UserCreateDTO { Username = "newuser", Email = "new@example.com" };
//            _mockUserService.Setup(s => s.CreateUserAsync(It.IsAny<UserCreateDTO>())).Returns(Task.CompletedTask);

//            // Act
//            var result = await _controller.CreateUser(userCreateDto);

//            // Assert
//            Assert.IsType<OkResult>(result);
//        }

//        [Fact]
//        public async Task CreateUser_ReturnsBadRequest_WhenModelIsInvalid()
//        {
//            // Arrange
//            var userCreateDto = new UserCreateDTO();
//            _controller.ModelState.AddModelError("Username", "Required");

//            // Act
//            var result = await _controller.CreateUser(userCreateDto);

//            // Assert
//            Assert.IsType<BadRequestObjectResult>(result);
//        }

//        [Fact]
//        public async Task UpdateUser_ReturnsOkResult_WhenModelIsValid()
//        {
//            // Arrange
//            var userUpdateDto = new UserUpdateDTO { Username = "updated", Email = "updated@example.com" };
//            _mockUserService.Setup(s => s.UpdateUserAsync(It.IsAny<UserUpdateDTO>(), It.IsAny<int>())).Returns(Task.CompletedTask);

//            // Act
//            var result = await _controller.UpdateUser(userUpdateDto, 1);

//            // Assert
//            Assert.IsType<OkResult>(result);
//        }

//        [Fact]
//        public async Task UpdateUser_ReturnsBadRequest_WhenModelIsInvalid()
//        {
//            // Arrange
//            var userUpdateDto = new UserUpdateDTO();
//            _controller.ModelState.AddModelError("Username", "Required");

//            // Act
//            var result = await _controller.UpdateUser(userUpdateDto, 1);

//            // Assert
//            Assert.IsType<BadRequestObjectResult>(result);
//        }

//        [Fact]
//        public async Task DeleteUser_ReturnsOkResult_WhenUserExists()
//        {
//            // Arrange
//            _mockUserService.Setup(s => s.DeleteUserByIdAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

//            // Act
//            var result = await _controller.DeleteUser(1);

//            // Assert
//            Assert.IsType<OkResult>(result);
//        }
//    }
//}