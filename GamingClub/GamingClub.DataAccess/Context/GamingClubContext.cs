using GamingClub.Core.Entities;
using GamingClub.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GamingClub.Data.Context
{
    public class GamingClubContext(DbContextOptions<GamingClubContext> dbContext) : DbContext
    {       
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ReservationEntity> Reservations { get; set; }
        public DbSet<GamingStationEntity> GamingStations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
