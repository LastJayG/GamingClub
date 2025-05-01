using GamingClub.Application.DTOs;
using GamingClub.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GamingClub.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ReservationsController(IReservationRepository _reservationRepository) : Controller
    {
        [HttpGet("{id}", Name = "GetReservationById")]
        public async Task<IActionResult> GetReservationByIdAsync(int id)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(id);
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

            await _reservationRepository.CreateReservationAsync(reservationDTO);
            return CreatedAtRoute("GetReservationById",
                new { id = reservationDTO.Id },
                reservationDTO);

            return Ok();
        }
        [HttpPut("UpdateReservation")]
        public async Task<IActionResult> UpdateReservation([FromBody] ReservationDTO reservationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _reservationRepository.UpdateReservationAsync(reservationDTO);
            return Ok();
        }
        [HttpDelete("DeleteReservationById")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            await _reservationRepository.DeleteReservationByIdAsync(id);
            return Ok();
        }
    }
}
