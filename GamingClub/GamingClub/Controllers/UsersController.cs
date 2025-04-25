using GamingClub.Data;
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

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsers(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser()
        {

            return Ok();
        }
    }
}
