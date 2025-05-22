using GamingClub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingClub.Data.Configurations
{
    public class GamingStationConfiguration : IEntityTypeConfiguration<GamingStationEntity>
    {
        public void Configure(EntityTypeBuilder<GamingStationEntity> builder)
        {
            builder
                .HasMany(g => g.Reservations)
                .WithOne(r => r.GamingStation);
        }
    }
}
