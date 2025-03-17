using GamingClub.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GamingClub.Controllers
{
	[Route("Account")]
	public class AccountController : Controller
	{
		public IActionResult Account()
		{
			var user = new UserVM { Name = "Aasas", Email = "sds"};
			return View(user);
		}
	}
}
