using GamingClub.ViewModels;
using GamingClub.Services;
using Microsoft.AspNetCore.Mvc;

namespace GamingClub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var userVM = new UserVM
            {
                Username = user.Username,
                Email = user.Email,
                ReservationHistory = user.ReservationHistory,
            };
            return Ok(userVM);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserVM user) // В UserVM нет айди и пароля для создания пользователя => а как создать нового пользователя, чтобы Controllers не знал о Models
        {
            //if (user == null)
            //    return BadRequest();
            //await _userService.CreateUserAsync(user);

            //return Ok(user);
            return Ok();
        }
    }
}
