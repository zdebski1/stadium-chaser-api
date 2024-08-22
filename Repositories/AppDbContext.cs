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

        public DbSet<Stadium> Stadium { get; set; }
        public DbSet<Visit> Visit { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Stadium>(entity =>
            {
                entity.ToTable("stadium", "tlkp");
                entity.HasKey(e => e.StadiumId);
                entity.Property(e => e.StadiumId).HasColumnName("stadiumid");
                entity.Property(e => e.StadiumName).HasColumnName("stadiumname");
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.ToTable("visit", "dbo");
                entity.HasKey(e => e.VisitId);
                entity.Property(e => e.VisitId).HasColumnName("visitid");
                entity.Property(e => e.StadiumId).HasColumnName("stadiumid");
                entity.Property(e => e.VisitDate).HasColumnName("visitdate");
                entity.Property(e => e.ModifyBy).HasColumnName("modifyby");
                entity.Property(e => e.ModifyDate).HasColumnName("modifydate");
                entity.Property(e => e.CreateBy).HasColumnName("createby");
                entity.Property(e => e.CreateDate).HasColumnName("createdate");
                entity.Property(e => e.IsDeleted).HasColumnName("isdeleted");
            });
        }
    }
}
