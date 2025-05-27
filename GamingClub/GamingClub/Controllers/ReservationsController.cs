using FluentValidation;
using GamingClub.Application.DTOs.Reservation;
using GamingClub.Application.DTOs.User;
using GamingClub.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GamingClub.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ReservationsController(IValidator<ReservationDTO> validator, 
                                        IReservationService reservationService) : Controller
    {
        [HttpGet("{id}", Name = "GetReservationById")]
        public async Task<IActionResult> GetReservationByIdAsync(int id)
        {
            var reservation = await reservationService.GetReservationByIdAsync(id);
            if (reservation == null) return NotFound();
            return Ok(reservation);
        }

        [HttpPost("CreateReservation")]
        public async Task<IActionResult> CreateReservation([FromBody] ReservationDTO reservationDTO)
        {
            var result = await validator.ValidateAsync(reservationDTO);

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
                return BadRequest();
            }

            await reservationService.CreateReservationAsync(reservationDTO);

            return Ok();
        }

        [HttpPut("UpdateReservation/{userId}/{id}")]
        public async Task<IActionResult> UpdateReservation([FromBody] ReservationUpdateDTO reservationDTO, int id, int userId)
        {
            await reservationService.UpdateReservationAsync(reservationDTO, id, userId);
            return Ok();
        }

        [HttpGet("GetAvailableReservationStartTimePoints")]
        public async Task<IActionResult> GetStartTimePointsForTimeSpan(TimeSpan timeSpan)
        {
            var list = await reservationService.ReturnAvailableReservationStartTimePointsAsync(timeSpan);
            return Ok(list);
        }

        [HttpDelete("DeleteReservationById/{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            await reservationService.DeleteReservationByIdAsync(id);
            return Ok();
        }
    }
}
