using Microsoft.EntityFrameworkCore;

using CarRentalPlatform.Domain.Models.CarAds;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static CarRentalPlatform.Domain.Models.ModelConstants.Common;


namespace CarRentalPlatform.Infrastructure.Persistence.Configurations
{
    internal class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(MaxNameLength);
        }
    }
}
