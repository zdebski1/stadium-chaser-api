using Microsoft.EntityFrameworkCore;
using stadiumChaserApi.Entities;
using stadiumChaserApi.Repositories;
using stadiumChaserApi.Services.Interfaces;

namespace stadiumChaserApi.Services
{
    public class VisitService : IVisitService
    {
        private readonly AppDbContext _context;

        public VisitService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateVisitAsync(Visit visit)
        {
            bool stadiumExists = await _context.Stadium.AnyAsync(s => s.StadiumId == visit.StadiumId);
            if (!stadiumExists)
            {
                var validStadiums = await _context.Stadium
                    .Select(s => new { s.StadiumId, s.StadiumName })
                    .ToListAsync();

                var stadiumList = validStadiums
                    .Select(s => $"{s.StadiumId} ({s.StadiumName})")
                    .ToList();

                return $"Invalid StadiumId. Please use one of the following Ids: {string.Join(", ", stadiumList)}";
            }

            visit.CreateBy = "ZDEBSKI"; // This will be replaced with user authentication in the future
            visit.CreateDate = DateTime.UtcNow;

            visit.ModifyBy = null;
            visit.ModifyDate = null;

            _context.Visit.Add(visit);
            await _context.SaveChangesAsync();

            return "Visit created successfully.";
        }

        public async Task<Visit> GetVisitAsync(int visitId)
        {
            var visit = await _context.Visit
                .FirstOrDefaultAsync(v => v.VisitId == visitId && v.IsDeleted == false);

            return visit;
        }
    }
}
