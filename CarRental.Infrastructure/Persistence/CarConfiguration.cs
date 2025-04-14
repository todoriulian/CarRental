using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Persistence
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(car => car.Guid);
            builder.Property(car => car.Guid).ValueGeneratedNever();

            builder.Property(car => car.LicensePlate)
                .IsRequired()
                .HasMaxLength(7);

            builder.Property(car => car.Model)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(car => car.Manufacturer)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(car => car.ManufactureYear)
                .IsRequired();

            builder.Property(car => car.Motor)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.Property(car => car.Fuel)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(car => car.Seats)
                .IsRequired();

            builder.Property(car => car.IdCategory)
                .IsRequired();

            builder.HasOne(car => car.Category)
                .WithMany()
                .HasForeignKey(car => car.IdCategory);


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