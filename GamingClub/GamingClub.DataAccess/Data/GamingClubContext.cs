using GamingClub.DataAccess.Configurations;
using GamingClub.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamingClub.Data
{
    public class GamingClubContext(DbContextOptions<GamingClubContext> dbContext) : DbContext
    {       
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<GameReservationEntity> Reservations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
