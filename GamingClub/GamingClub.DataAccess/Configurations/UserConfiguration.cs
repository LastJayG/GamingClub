using GamingClub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamingClub.Domain.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder
                .HasMany(u => u.Reservations)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);
        }
    }
}
