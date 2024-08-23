using Microsoft.AspNetCore.Mvc;
using stadiumChaserApi.Entities;
using stadiumChaserApi.Services.Interfaces;
using System.Threading.Tasks;

namespace stadiumChaserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly IVisitService _visitService;

        public VisitController(IVisitService visitService)
        {
            _visitService = visitService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVisit([FromBody] Visit visit)
        {
            if (visit == null)
            {
                return BadRequest("A visit is required.");
            }

            string result = await _visitService.CreateVisitAsync(visit);

            if (result != "Visit created successfully.")
            {
                return BadRequest(result);
            }

            return Ok(result); 
        }
    }
}
