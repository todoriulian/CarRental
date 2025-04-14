using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Persistence
{
    public class CarDetailConfiguration : IEntityTypeConfiguration<CarDetail>
    {
        public void Configure(EntityTypeBuilder<CarDetail> builder)
        {
            builder.HasKey(carDetail => carDetail.Guid);
            builder.Property(carDetail => carDetail.Guid).ValueGeneratedNever();

            builder.Property(carDetail => carDetail.IdCar)
                .IsRequired();

            builder.Property(carDetail => carDetail.ITP)
                .IsRequired();

            builder.Property(carDetail => carDetail.Assurance)
                .IsRequired();

            builder.Property(carDetail => carDetail.RoadTax)
                .IsRequired();

            builder.Property(carDetail => carDetail.Details)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne(carDetail => carDetail.Car)
                .WithMany()
                .HasForeignKey(carDetail => carDetail.IdCar);


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