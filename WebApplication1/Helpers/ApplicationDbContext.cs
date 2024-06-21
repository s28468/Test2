using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Astronaut> Astronauts { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<AstronautMission> AstronautMissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AstronautMission>()
                .HasKey(am => new { am.AstronautId, am.MissionId });

            modelBuilder.Entity<AstronautMission>()
                .HasOne(am => am.Astronaut)
                .WithMany(a => a.AstronautMissions)
                .HasForeignKey(am => am.AstronautId);

            modelBuilder.Entity<AstronautMission>()
                .HasOne(am => am.Mission)
                .WithMany(m => m.AstronautMissions)
                .HasForeignKey(am => am.MissionId);
        }
    }
}