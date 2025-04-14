using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Persistence
{
    public class DrivingLicenceCategoryDriverConfiguration : IEntityTypeConfiguration<DrivingLicenceCategoryDriver>
    {
        public void Configure(EntityTypeBuilder<DrivingLicenceCategoryDriver> builder)
        {
            builder.HasKey(d => d.Guid);
            builder.Property(d => d.Guid).ValueGeneratedNever();

            builder.Property(d => d.IdEmployees)
                .IsRequired();

            builder.Property(d => d.IdDrivingLicenceCategory)
                .IsRequired();

            builder.HasOne(d => d.Employee)
                .WithMany()
                .HasForeignKey(d => d.IdEmployees);

            builder.HasOne(d => d.DrivingLicenceCatgory)
                .WithMany()
                .HasForeignKey(d => d.IdDrivingLicenceCategory);


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