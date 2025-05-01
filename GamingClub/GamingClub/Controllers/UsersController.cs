using Microsoft.AspNetCore.Mvc;
using GamingClub.Data.Interfaces;
using GamingClub.Application.DTOs;

namespace GamingClub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IUserRepository _userRepository) : ControllerBase
    {
        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            var result = new UserWithReservationsDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Reservations = user.Reservations?.Select(r => new ReservationDTO
                {
                    Id = r.Id,
                    StartDate = r.StartDate,
                    EndDate = r.EndDate
                }).ToList() ?? new List<ReservationDTO>()
            };

            return Ok(result);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userRepository.CreateUserAsync(userDTO);

            return Ok();
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            await _userRepository.UpdateUserAsync(userDTO);
            return Ok();
        }
        [HttpDelete("DeleteUserById")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userRepository.DeleteUserByIdAsync(id);
            return Ok();
        }
    }

}

