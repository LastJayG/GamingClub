using GamingClub.Application.DTOs;
using GamingClub.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GamingClub.Controllers
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
