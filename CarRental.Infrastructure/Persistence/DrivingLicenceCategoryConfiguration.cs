using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Persistence
{
    public class DrivingLicenceCategoryConfiguration : IEntityTypeConfiguration<DrivingLicenceCategory>
    {
        public void Configure(EntityTypeBuilder<DrivingLicenceCategory> builder)
        {
            builder.HasKey(category => category.Guid);
            builder.Property(category => category.Guid).ValueGeneratedNever();

            builder.Property(category => category.Description)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(category => category.Type)
                .IsRequired()
                .HasMaxLength(2);

            builder.Property(category => category.DrivingLicence)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(category => category.DrivingLicenceRenew)
                .IsRequired();


            // Configure BaseAuditableEntity properties
            builder.Property(carDetail => carDetail.Created)
                .IsRequired();

            builder.Property(carDetail => carDetail.LastModified);

            builder.Property(carDetail => carDetail.IsDeleted)
                .IsRequired();

            builder.Property(carDetail => carDetail.Deleted);
        }
    }
}