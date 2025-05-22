using GamingClub.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GamingClub.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class GamingStationsController(IGamingStationRepository gamingStationRepository) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetGamingStationsAsync()
        {
            return Ok(await gamingStationRepository.GetGamingStationsAsync());
        }
    }
}
