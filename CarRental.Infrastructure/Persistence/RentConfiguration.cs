using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Persistence
{
    public class RentConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.HasKey(rent => rent.Guid);
            builder.Property(rent => rent.Guid).ValueGeneratedNever();

            builder.Property(rent => rent.IdCar)
                .IsRequired();

            builder.Property(rent => rent.Available)
                .IsRequired();

            builder.Property(rent => rent.LastRentDate)
                .IsRequired();

            builder.HasOne(rent => rent.Car)
                .WithMany()
                .HasForeignKey(rent => rent.IdCar);



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