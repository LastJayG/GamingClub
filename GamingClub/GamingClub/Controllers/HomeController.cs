using GamingClub.Models.Home;
using GamingClub.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace GamingClub.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
			var model = new GreetingModel { Message = "It's a place where a game starts" };
			return View(model);
        }

		public IActionResult About()
		{
			var model = new AboutViewModel { 
				Title = "О нас:", 
				AboutUsFacts = {"1", "2", "3", "4" } 
			};
			return View(model);
		}
		public IActionResult Services()
		{
			return View();
		}

	}
}
