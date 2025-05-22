using GamingClub.Application.DTOs.Reservation;
using GamingClub.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GamingClub.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ReservationsController(IReservationService reservationService) : Controller
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await reservationService.CreateReservationAsync(reservationDTO);

            return Ok();
        }

        [HttpPut("UpdateReservation/{id}")]
        public async Task<IActionResult> UpdateReservation([FromBody] ReservationUpdateDTO reservationDTO, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await reservationService.UpdateReservationAsync(reservationDTO, id);
            return Ok();
        }

        //[HttpDelete("DeleteReservationById")]
        //public async Task<IActionResult> DeleteReservation(int id)
        //{
        //    await _reservationRepository.DeleteReservationByIdAsync(id);
        //    return Ok();
        //}
    }
}
