using GamingClub.Core.Entities;
using GamingClub.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GamingClub.Data.Context
{
    public class GamingClubContext : DbContext
    {
        public GamingClubContext(DbContextOptions<GamingClubContext> options) : base(options) { }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ReservationEntity> Reservations { get; set; }
        public DbSet<GamingStationEntity> GamingStations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Почему БД правильно создалась, когда ApplyConfiguration был только один (для UserConfiguration)???
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new GamingStationConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("host=localhost;port=3306;database=gamingclubdb;user=root;password=11111");
        }
    }
}
