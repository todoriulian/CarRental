using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Persistence
{
    public class RentHistoryConfiguration : IEntityTypeConfiguration<RentHistory>
    {
        public void Configure(EntityTypeBuilder<RentHistory> builder)
        {
            builder.HasKey(rentHistory => rentHistory.Guid);
            builder.Property(rentHistory => rentHistory.Guid).ValueGeneratedNever();

            builder.Property(rentHistory => rentHistory.IdCar)
                .IsRequired();

            builder.Property(rentHistory => rentHistory.IdClient)
                .IsRequired();

            builder.Property(rentHistory => rentHistory.RentDate)
                .IsRequired();

            builder.Property(rentHistory => rentHistory.ReturnDate)
                .IsRequired();

            builder.Property(rentHistory => rentHistory.WithDriver)
                .IsRequired();

            builder.Property(rentHistory => rentHistory.IdEmployees);

            builder.HasOne(rentHistory => rentHistory.Car)
                .WithMany()
                .HasForeignKey(rentHistory => rentHistory.IdCar);

            builder.HasOne(rentHistory => rentHistory.Client)
                .WithMany()
                .HasForeignKey(rentHistory => rentHistory.IdClient);

            builder.HasOne(rentHistory => rentHistory.Employee)
                .WithMany()
                .HasForeignKey(rentHistory => rentHistory.IdEmployees);


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