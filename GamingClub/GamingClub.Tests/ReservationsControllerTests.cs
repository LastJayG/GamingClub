using GamingClub.Application.DTOs.Reservation;
using GamingClub.Application.Interfaces;
using GamingClub.Server.Controllers;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GamingClub.Tests
{
    public class ReservationsControllerTests
    {
        private readonly Mock<IReservationService> _mockReservationService;
        private readonly Mock<IValidator<ReservationRequestDTO>> _mockValidator;
        private readonly ReservationsController _controller;

        public ReservationsControllerTests()
        {
            _mockReservationService = new Mock<IReservationService>();
            _mockValidator = new Mock<IValidator<ReservationRequestDTO>>();
            _controller = new ReservationsController(_mockValidator.Object, _mockReservationService.Object);
        }

        [Fact]
        public async Task GetReservationById_ReturnsOkResult_WhenReservationExists()
        {
            // Arrange
            var testReservation = new ReservationRequestDTO { Id = 1, UserId = 1, GamingStationId = 101 };
            _mockReservationService.Setup(s => s.GetReservationByIdAsync(1)).ReturnsAsync(testReservation);

            // Act
            var result = await _controller.GetReservationByIdAsync(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedReservation = Assert.IsType<ReservationRequestDTO>(okResult.Value);
            Assert.Equal(testReservation.Id, returnedReservation.Id);
        }

        [Fact]
        public async Task GetReservationById_ReturnsNotFound_WhenReservationDoesNotExist()
        {
            // Arrange
            _mockReservationService.Setup(s => s.GetReservationByIdAsync(It.IsAny<int>())).ReturnsAsync((ReservationRequestDTO)null);

            // Act
            var result = await _controller.GetReservationByIdAsync(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CreateReservation_ReturnsOkResult_WhenModelIsValid()
        {
            // Arrange
            var reservationDTO = new ReservationRequestDTO { UserId = 1, GamingStationId = 101 };
            var validationResult = new FluentValidation.Results.ValidationResult();
            _mockValidator.Setup(v => v.ValidateAsync(reservationDTO, default)).ReturnsAsync(validationResult);
            _mockReservationService.Setup(s => s.CreateReservationAsync(reservationDTO)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.CreateReservation(reservationDTO);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task CreateReservation_ReturnsBadRequest_WhenModelIsInvalid()
        {
            // Arrange
            var reservationDTO = new ReservationRequestDTO();
            var validationResult = new FluentValidation.Results.ValidationResult();
            validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure("UserId", "Required"));
            _mockValidator.Setup(v => v.ValidateAsync(reservationDTO, default)).ReturnsAsync(validationResult);

            // Act
            var result = await _controller.CreateReservation(reservationDTO);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task GetAvailableTimeSlots_ReturnsCorrectSlots()
        {
            // Arrange
            var timeSpan = new TimeSpan(2, 0, 0);
            var expectedSlots = new List<string> { "10:00", "12:30", "15:00" };
            _mockReservationService.Setup(s => s.GetAvailableTimeSlotsAsync(timeSpan)).ReturnsAsync(expectedSlots);

            // Act
            var result = await _controller.GetStartTimePointsForTimeSpan(timeSpan);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedSlots = Assert.IsType<List<string>>(okResult.Value);
            Assert.Equal(expectedSlots, returnedSlots);
        }

        [Fact]
        public async Task UpdateReservation_ReturnsOkResult_WhenSuccessful()
        {
            // Arrange
            var reservationDTO = new ReservationUpdateDTO();
            _mockReservationService.Setup(s => s.UpdateReservationAsync(reservationDTO, 1, 1)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.UpdateReservation(reservationDTO, 1, 1);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteReservation_ReturnsOkResult_WhenSuccessful()
        {
            // Arrange
            _mockReservationService.Setup(s => s.DeleteReservationByIdAsync(1)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteReservation(1);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}