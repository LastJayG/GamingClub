using GamingClub.Services;
using Microsoft.AspNetCore.Mvc;

namespace GamingClub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            //var user = await userService.GetUserByIdAsync(id);
            //if (user == null)
            //{
            //    return NotFound();
            //}
            //var userVM = new UserVM
            //{
            //    Username = user.Username,
            //    Email = user.Email,
            //    ReservationHistory = user.ReservationHistory,
            //};
            //return Ok(userVM);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser() // В UserVM нет айди и пароля для создания пользователя => а как создать нового пользователя, чтобы Controllers не знал о Models
        {
            //if (user == null)
            //    return BadRequest();
            //await _userService.CreateUserAsync(user);

            //return Ok(user);
            return Ok();
        }
    }
}
