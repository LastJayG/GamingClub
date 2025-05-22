using GamingClub.Data.Configurations;
using GamingClub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GamingClub.Data.Context
{
    public class GamingClubContext(IConfiguration configuration) : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ReservationEntity> Reservations { get; set; }
        public DbSet<GamingStationEntity> GamingStations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new GamingStationConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
