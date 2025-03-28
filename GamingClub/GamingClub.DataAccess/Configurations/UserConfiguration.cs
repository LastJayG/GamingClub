using GamingClub.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingClub.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder
                .HasMany(u => u.GameReservations)
                .WithOne(gr => gr.User)
                .HasForeignKey(gr => gr.UserId);
        }
    }
}
