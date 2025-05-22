using Microsoft.AspNetCore.Mvc;

namespace GamingClub.Server.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class TournamentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return File("~/tournaments.html", "text/html");
        }

    }
}
