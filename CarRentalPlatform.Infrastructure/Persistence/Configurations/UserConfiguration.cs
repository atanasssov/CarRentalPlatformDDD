using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

using CarRentalPlatform.Infrastructure.Identity;

namespace CarRentalPlatform.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasOne(u => u.Dealer)
                .WithOne()
                .HasForeignKey<User>("DealerId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
