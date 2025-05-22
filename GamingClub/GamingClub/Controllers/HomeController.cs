using Microsoft.AspNetCore.Mvc;

namespace GamingClub.Server.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return File("~/index.html", "text/html");
        }

	}
}
