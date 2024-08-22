using Microsoft.AspNetCore.Mvc;
using stadiumChaserApi.Repositories;
using stadiumChaserApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace stadiumChaserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StadiumController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stadium>>> GetStadiums()
        {
            var stadiums = await _context.Stadium.ToListAsync();
            return Ok(stadiums);
        }
    }
}
