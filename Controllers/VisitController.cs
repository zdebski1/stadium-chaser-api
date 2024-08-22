using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stadiumChaserApi.Entities;
using stadiumChaserApi.Repositories;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace stadiumChaserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VisitController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVisit([FromBody] Visit visit)
        {
            if (visit == null)
            {
                return BadRequest("A visit is required.");
            }

            bool stadiumExists = await _context.Stadium.AnyAsync(s => s.StadiumId == visit.StadiumId);
            if (!stadiumExists)
            {
                var validStadiums = await _context.Stadium
                    .Select(s => new { s.StadiumId, s.StadiumName })
                    .ToListAsync();

                var stadiumList = validStadiums
                    .Select(s => $"{s.StadiumId} ({s.StadiumName})")
                    .ToList();

                return BadRequest($"Invalid StadiumId. Please use one of the following Ids: {string.Join(", ", stadiumList)}");
            }

            visit.CreateBy = "ZDEBSKI"; // will be user authentication in the future
            visit.CreateDate = DateTime.UtcNow;


            visit.ModifyBy = null;
            visit.ModifyDate = null;

            _context.Visit.Add(visit);
            await _context.SaveChangesAsync();

            return StatusCode(200);
        }

    }
}
