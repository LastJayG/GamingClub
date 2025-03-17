using GamingClub.Models.Home;
using Microsoft.AspNetCore.Mvc;

namespace GamingClub.Controllers
{
	//[Route("Home")]
	public class HomeController : Controller
    {
        public IActionResult Index()
        {
			var model = new GreetingModel { Message = "It's a place where a game starts" };
			return View(model);
        }

		public IActionResult About()
		{
			
			return View();
		}
		public IActionResult Services()
		{
			return View();
		}

	}
}
