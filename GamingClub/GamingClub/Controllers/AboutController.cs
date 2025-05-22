using Microsoft.AspNetCore.Mvc;

namespace GamingClub.Server.Controllers
{
    [ApiController]
    [Route("/[controller]")]

    public class AboutController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return File("~/about.html", "text/html");
        }

    }
}
