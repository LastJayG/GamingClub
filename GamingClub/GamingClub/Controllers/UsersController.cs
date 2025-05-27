using Microsoft.AspNetCore.Mvc;
using GamingClub.Application.DTOs.User;
using GamingClub.Application.Interfaces;
using FluentValidation;

namespace GamingClub.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IValidator<UserDTO> validator, IUserService userService) : ControllerBase
    {
        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpGet("GetUserWithReservations/{id}")]
        public async Task<IActionResult> GetUserWithReservations(int id)
        {
            var user = await userService.GetUserWithReservationsByIdAsync(id);
            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpGet("FromFile/{id}")]
        public async Task<IActionResult> GetUserFromFile(int id)
        {
            var user = await userService.GetUserFromFileAsync(id);
            if (user == null)
                return NotFound($"User file for ID {id} not found.");

            return Ok(user);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO user)
        {
            //var result = await validator.ValidateAsync(user);

            //if (!result.IsValid)
            //{
            //    foreach (var failure in result.Errors)
            //    {
            //        Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
            //    }
            //    return BadRequest();
            //}

            await userService.CreateUserAsync(user);

            return Ok();
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDTO user, [FromRoute] int id)
        {
            await userService.UpdateUserAsync(user, id);
            return Ok();
        }

        [HttpDelete("DeleteUserById")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await userService.DeleteUserByIdAsync(id);
            return Ok();
        }
    }

}

