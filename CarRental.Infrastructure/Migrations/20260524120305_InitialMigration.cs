using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarCategories",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCategories", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "DrivingLicenceCatgories",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DrivingLicence = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DrivingLicenceRenew = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrivingLicenceCatgories", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HireContract = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    SalaryPerKm = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    TipEmployees = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OccupationalMedicine = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ManufactureYear = table.Column<int>(type: "int", nullable: false),
                    Motor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Fuel = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    IdCategory = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Cars_CarCategories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "CarCategories",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrivingLicenceCategoryDrivers",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEmployees = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDrivingLicenceCategory = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrivingLicenceCategoryDrivers", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_DrivingLicenceCategoryDrivers_DrivingLicenceCatgories_IdDrivingLicenceCategory",
                        column: x => x.IdDrivingLicenceCategory,
                        principalTable: "DrivingLicenceCatgories",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrivingLicenceCategoryDrivers_Employees_IdEmployees",
                        column: x => x.IdEmployees,
                        principalTable: "Employees",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarsDetails",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCar = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ITP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Assurance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoadTax = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsDetails", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_CarsDetails_Cars_IdCar",
                        column: x => x.IdCar,
                        principalTable: "Cars",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DriverHistories",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCar = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEmployees = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverHistories", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_DriverHistories_Cars_IdCar",
                        column: x => x.IdCar,
                        principalTable: "Cars",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DriverHistories_Employees_IdEmployees",
                        column: x => x.IdEmployees,
                        principalTable: "Employees",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceHistories",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCar = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceHistories", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PriceHistories_Cars_IdCar",
                        column: x => x.IdCar,
                        principalTable: "Cars",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rent",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCar = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    LastRentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rent", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Rent_Cars_IdCar",
                        column: x => x.IdCar,
                        principalTable: "Cars",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentHistories",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCar = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdClient = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WithDriver = table.Column<bool>(type: "bit", nullable: false),
                    IdEmployees = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentHistories", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_RentHistories_Cars_IdCar",
                        column: x => x.IdCar,
                        principalTable: "Cars",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentHistories_Client_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Client",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentHistories_Employees_IdEmployees",
                        column: x => x.IdEmployees,
                        principalTable: "Employees",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdClient = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPriceHistory = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Payments_Client_IdClient",
                        column: x => x.IdClient,
                        principalTable: "Client",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_PriceHistories_IdPriceHistory",
                        column: x => x.IdPriceHistory,
                        principalTable: "PriceHistories",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_IdCategory",
                table: "Cars",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_CarsDetails_IdCar",
                table: "CarsDetails",
                column: "IdCar");

            migrationBuilder.CreateIndex(
                name: "IX_DriverHistories_IdCar",
                table: "DriverHistories",
                column: "IdCar");

            migrationBuilder.CreateIndex(
                name: "IX_DriverHistories_IdEmployees",
                table: "DriverHistories",
                column: "IdEmployees");

            migrationBuilder.CreateIndex(
                name: "IX_DrivingLicenceCategoryDrivers_IdDrivingLicenceCategory",
                table: "DrivingLicenceCategoryDrivers",
                column: "IdDrivingLicenceCategory");

            migrationBuilder.CreateIndex(
                name: "IX_DrivingLicenceCategoryDrivers_IdEmployees",
                table: "DrivingLicenceCategoryDrivers",
                column: "IdEmployees");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_IdClient",
                table: "Payments",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_IdPriceHistory",
                table: "Payments",
                column: "IdPriceHistory");

            migrationBuilder.CreateIndex(
                name: "IX_PriceHistories_IdCar",
                table: "PriceHistories",
                column: "IdCar");

            migrationBuilder.CreateIndex(
                name: "IX_Rent_IdCar",
                table: "Rent",
                column: "IdCar");

            migrationBuilder.CreateIndex(
                name: "IX_RentHistories_IdCar",
                table: "RentHistories",
                column: "IdCar");

            migrationBuilder.CreateIndex(
                name: "IX_RentHistories_IdClient",
                table: "RentHistories",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_RentHistories_IdEmployees",
                table: "RentHistories",
                column: "IdEmployees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarsDetails");

            migrationBuilder.DropTable(
                name: "DriverHistories");

            migrationBuilder.DropTable(
                name: "DrivingLicenceCategoryDrivers");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Rent");

            migrationBuilder.DropTable(
                name: "RentHistories");

            migrationBuilder.DropTable(
                name: "DrivingLicenceCatgories");

            migrationBuilder.DropTable(
                name: "PriceHistories");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "CarCategories");
        }
    }
}
