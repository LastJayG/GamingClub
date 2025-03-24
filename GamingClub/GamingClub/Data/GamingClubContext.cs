using GamingClub.Models;
using GamingClub.Models.Prices;
using Microsoft.EntityFrameworkCore;

namespace GamingClub.Data
{
    public class GamingClubContext : DbContext
    {
        public GamingClubContext(DbContextOptions<GamingClubContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; } // все пользователи
        public DbSet<GameModel> Games { get; set; } // список зарезервированных игр-мест  
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserModel>(entity => 
            {
                entity.HasKey(u => u.Id); 
                entity.Property(u => u.Username).IsRequired().HasMaxLength(50); 
                entity.Property(u => u.Email).IsRequired().HasMaxLength(50);
                entity.Property(u => u.ReservationHistory).IsRequired();
                entity.Property(u => u.HashPassword).HasDefaultValueSql("GETHASHPASSWORD()");
            }
            );
            modelBuilder.Entity<GameModel>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.CasualPriceStandard).IsRequired();
                entity.Property(u => u.WeekendPriceStandard).IsRequired();
                entity.Property(u => u.CasualPriceVip).IsRequired();
                entity.Property(u => u.WeekendPriceVip).IsRequired();
                entity.Property(u => u.StartTime).IsRequired();
                entity.Property(u => u.EndTime).IsRequired();
            }
           );
        }
    }
}
