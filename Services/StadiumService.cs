using stadiumChaserApi.Repositories;
using Microsoft.EntityFrameworkCore;
using stadiumChaserApi.Entities;
using stadiumChaserApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace stadium_chaser_api.Services
{
    public class StadiumService: IStadiumService
    {
        private readonly AppDbContext _context;
        public StadiumService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Stadium>>> GetStadiumAsync()
        {
            var Stadium = await _context.Stadium.ToListAsync();

            return Stadium;
        }
    }
}
