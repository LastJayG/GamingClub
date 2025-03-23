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
            };
            return Ok(userVM);
        }
        //[HttpPost]
        //public async Task<IActionResult> CreateUser([FromBody] UserModel user) // USERCREATEVM НАДО СОЗДАТЬ
        //{
        //    if (user == null)
        //        return BadRequest();

        //    await _userService.CreateUserAsync(user);

        //    return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        //}
    }
}
