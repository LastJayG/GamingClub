using GamingClub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingClub.Domain.Configurations
{
    public class ReservationUnitConfiguration : IEntityTypeConfiguration<ReservationUnitEntity>
    {
        public void Configure(EntityTypeBuilder<ReservationUnitEntity> builder)
        {
            builder
                .HasOne(ru => ru.Reservation)
                .WithMany(r => r.ReservationUnits)
                .HasForeignKey(r => r.ReservationId);
            builder
               .HasOne(ru => ru.GamingStation)
               .WithMany(g => g.ReservationUnits)
               .HasForeignKey(ru => ru.ReservationId);
        }
    }
}
