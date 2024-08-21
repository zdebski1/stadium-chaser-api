using Microsoft.EntityFrameworkCore;
using stadiumChaserApi.Entities;

namespace stadiumChaserApi.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Stadium> Stadiums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stadium>(entity =>
            {
                entity.ToView("vw_listofstadiums", "dbo"); // Use 'dbo' or the correct schema name
                entity.HasNoKey();
            });
        }
    }
}
