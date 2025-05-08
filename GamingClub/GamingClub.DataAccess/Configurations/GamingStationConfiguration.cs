using GamingClub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingClub.Domain.Configurations
{
    public class GamingStationConfiguration : IEntityTypeConfiguration<GamingStationEntity>
    {
        public void Configure(EntityTypeBuilder<GamingStationEntity> builder)
        {
            builder
                .HasMany(g => g.ReservationUnits)
                .WithOne(ru => ru.GamingStation)
                .HasForeignKey(ru => ru.GamingStationId);
        }
    }
}
