using GamingClub.Core.Entities;
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
                .WithMany(g => g.GameStations);
        }
    }
}
