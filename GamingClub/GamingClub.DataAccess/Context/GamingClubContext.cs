using GamingClub.Domain.Configurations;
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
        public DbSet<ReservationUnitEntity> ReservationUnits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new GamingStationConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationUnitConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
