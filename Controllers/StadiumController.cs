using Microsoft.AspNetCore.Mvc;
using stadiumChaserApi.Entities;
using stadiumChaserApi.Services.Interfaces;

namespace stadiumChaserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumController : ControllerBase
    {
        private readonly IStadiumService _stadiumService;

        public StadiumController(IStadiumService stadiumService)
        {
            _stadiumService = stadiumService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stadium>>> GetStadiums()
        {
            var stadiums = await _stadiumService.GetStadiumAsync();
            return Ok(stadiums);
        }
    }
}
