using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Persistence
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(payment => payment.Guid);
            builder.Property(payment => payment.Guid).ValueGeneratedNever();

            builder.Property(payment => payment.IdClient)
                .IsRequired();

            builder.Property(payment => payment.IdPriceHistory)
                .IsRequired();

            builder.Property(payment => payment.Total)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.HasOne(payment => payment.Client)
                .WithMany()
                .HasForeignKey(payment => payment.IdClient);

            builder.HasOne(payment => payment.PriceHistory)
                .WithMany()
                .HasForeignKey(payment => payment.IdPriceHistory);



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