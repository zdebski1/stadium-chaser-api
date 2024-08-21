using Microsoft.AspNetCore.Mvc;
using stadiumChaserApi.Repositories;
using stadiumChaserApi.Entities;

namespace stadiumChaserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RecordsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> InsertRecord([FromBody] Record record)
        {
            _context.Records.Add(record);
            await _context.SaveChangesAsync();
            return Ok(record);
        }
    }
}
