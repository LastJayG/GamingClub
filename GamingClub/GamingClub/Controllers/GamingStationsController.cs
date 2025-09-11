using GamingClub.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GamingClub.Server.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class GamingStationsController(IGamingStationRepository gamingStationRepository,
                                          ILogger<GamingStationsController> logger) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetGamingStationsAsync()
        {
            try
            {
                logger.LogInformation("Request: GET Name: GetGamingStationsAsync");
                return Ok(await gamingStationRepository.GetGamingStationsAsync());
            }
            catch (Exception ex)
            {
                logger.LogError(message: ex.Message, ex);
                throw;
            }
        }
    }
}
