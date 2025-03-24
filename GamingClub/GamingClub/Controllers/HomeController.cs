using Microsoft.AspNetCore.Mvc;

namespace GamingClub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
	public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            var response = new
            {
                Message = "Welcome to GamingClub Api",
                Status = "OK",
                TimestampAttribute = DateTime.Now
            };
            return Ok(response);
        }

	}
}
