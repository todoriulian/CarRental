using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Persistence
{
    public class DriverHistoryConfiguration : IEntityTypeConfiguration<DriverHistory>
    {
        public void Configure(EntityTypeBuilder<DriverHistory> builder)
        {
            builder.HasKey(driverHistory => driverHistory.Guid);
            builder.Property(driverHistory => driverHistory.Guid).ValueGeneratedNever();

            builder.Property(driverHistory => driverHistory.IdCar)
                .IsRequired();

            builder.Property(driverHistory => driverHistory.IdEmployees)
                .IsRequired();

            builder.Property(driverHistory => driverHistory.RentDate)
                .IsRequired();

            builder.Property(driverHistory => driverHistory.ReturnDate)
                .IsRequired();

            builder.HasOne(driverHistory => driverHistory.Car)
                .WithMany()
                .HasForeignKey(driverHistory => driverHistory.IdCar);

            builder.HasOne(driverHistory => driverHistory.Employee)
                .WithMany()
                .HasForeignKey(driverHistory => driverHistory.IdEmployees);

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