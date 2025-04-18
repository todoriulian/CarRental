using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Persistence
{
    public class PriceHistoryConfiguration : IEntityTypeConfiguration<PriceHistory>
    {
        public void Configure(EntityTypeBuilder<PriceHistory> builder)
        {
            builder.HasKey(priceHistory => priceHistory.Guid);
            builder.Property(priceHistory => priceHistory.Guid).ValueGeneratedNever();

            builder.Property(priceHistory => priceHistory.IdCar)
                .IsRequired();

            builder.Property(priceHistory => priceHistory.StartDate)
                .IsRequired();

            builder.Property(priceHistory => priceHistory.FinalDate)
                .IsRequired();

            builder.Property(priceHistory => priceHistory.Price)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.HasOne(priceHistory => priceHistory.Car)
                .WithMany()
                .HasForeignKey(priceHistory => priceHistory.IdCar)
                .OnDelete(DeleteBehavior.Restrict);

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