﻿// <auto-generated />
using System;
using CarRental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRental.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarRental.Domain.Entities.Car", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fuel")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<Guid>("IdCategory")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<int>("ManufactureYear")
                        .HasColumnType("int");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Motor")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.HasKey("Guid");

                    b.HasIndex("IdCategory");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.CarCategory", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.HasKey("Guid");

                    b.ToTable("CarCategories");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.CarDetail", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Assurance")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("ITP")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdCar")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RoadTax")
                        .HasColumnType("datetime2");

                    b.HasKey("Guid");

                    b.HasIndex("IdCar");

                    b.ToTable("CarsDetails");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Guid");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.DriverHistory", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdCar")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdEmployees")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Guid");

                    b.HasIndex("IdCar");

                    b.HasIndex("IdEmployees");

                    b.ToTable("DriverHistories");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.DrivingLicenceCategory", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("DrivingLicence")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("DrivingLicenceRenew")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("Guid");

                    b.ToTable("DrivingLicenceCatgories");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.DrivingLicenceCategoryDriver", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdDrivingLicenceCategory")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdEmployees")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.HasKey("Guid");

                    b.HasIndex("IdDrivingLicenceCategory");

                    b.HasIndex("IdEmployees");

                    b.ToTable("DrivingLicenceCategoryDrivers");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.Employee", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<int>("HireContract")
                        .HasColumnType("int");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("OccupationalMedicine")
                        .HasColumnType("bit");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("SalaryPerKm")
                        .HasColumnType("decimal(3,2)");

                    b.Property<string>("TipEmployees")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Guid");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.Payment", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdClient")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPriceHistory")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Guid");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdPriceHistory");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.PriceHistory", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FinalDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdCar")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Guid");

                    b.HasIndex("IdCar");

                    b.ToTable("PriceHistories");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.Rent", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdCar")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastRentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Guid");

                    b.HasIndex("IdCar");

                    b.ToTable("Rent");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.RentHistory", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdCar")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdClient")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("IdEmployees")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("WithDriver")
                        .HasColumnType("bit");

                    b.HasKey("Guid");

                    b.HasIndex("IdCar");

                    b.HasIndex("IdClient");

                    b.HasIndex("IdEmployees");

                    b.ToTable("RentHistories");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.Car", b =>
                {
                    b.HasOne("CarRental.Domain.Entities.CarCategory", "Category")
                        .WithMany()
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.CarDetail", b =>
                {
                    b.HasOne("CarRental.Domain.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("IdCar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.DriverHistory", b =>
                {
                    b.HasOne("CarRental.Domain.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("IdCar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRental.Domain.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("IdEmployees")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.DrivingLicenceCategoryDriver", b =>
                {
                    b.HasOne("CarRental.Domain.Entities.DrivingLicenceCategory", "DrivingLicenceCatgory")
                        .WithMany()
                        .HasForeignKey("IdDrivingLicenceCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRental.Domain.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("IdEmployees")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DrivingLicenceCatgory");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.Payment", b =>
                {
                    b.HasOne("CarRental.Domain.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRental.Domain.Entities.PriceHistory", "PriceHistory")
                        .WithMany()
                        .HasForeignKey("IdPriceHistory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("PriceHistory");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.PriceHistory", b =>
                {
                    b.HasOne("CarRental.Domain.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("IdCar")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.Rent", b =>
                {
                    b.HasOne("CarRental.Domain.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("IdCar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarRental.Domain.Entities.RentHistory", b =>
                {
                    b.HasOne("CarRental.Domain.Entities.Car", "Car")
                        .WithMany()
                        .HasForeignKey("IdCar")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRental.Domain.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRental.Domain.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("IdEmployees");

                    b.Navigation("Car");

                    b.Navigation("Client");

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
