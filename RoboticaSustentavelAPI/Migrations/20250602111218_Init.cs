using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RoboticaSustentavelAPI.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    CPU = table.Column<string>(type: "text", nullable: false),
                    Ram = table.Column<string>(type: "text", nullable: false),
                    Storage = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateDonation = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SaleDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    PriceSale = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemDonations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ComputerId = table.Column<int>(type: "integer", nullable: true),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    CPU = table.Column<string>(type: "text", nullable: true),
                    DonationId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDonations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemDonations_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ItemDonations_Donations_DonationId",
                        column: x => x.DonationId,
                        principalTable: "Donations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemSales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ComputerId = table.Column<int>(type: "integer", nullable: true),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    CPU = table.Column<string>(type: "text", nullable: true),
                    SaleId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemSales_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ItemSales_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Computers",
                columns: new[] { "Id", "Brand", "CPU", "Quantity", "Ram", "Status", "Storage" },
                values: new object[,]
                {
                    { 1, "Dell", "Intel i7", 10, "16GB", 0, "512GB SSD" },
                    { 2, "HP", "Intel i5", 5, "8GB", 0, "1TB HDD" },
                    { 3, "Lenovo", "Intel i9", 3, "32GB", 0, "1TB SSD" },
                    { 4, null, "AMD Ryzen 5", 8, "16GB", 0, "256GB SSD" },
                    { 5, "Asus", "AMD Ryzen 7", 4, "32GB", 0, "2TB HDD" }
                });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "Id", "DateDonation" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "PriceSale", "SaleDate" },
                values: new object[,]
                {
                    { 1, 1500.0, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2000.0, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ItemDonations",
                columns: new[] { "Id", "Brand", "CPU", "ComputerId", "DonationId", "Quantity", "Status" },
                values: new object[,]
                {
                    { 1, "Dell", "Intel i7", 1, 1, 2, 1 },
                    { 2, "HP", "Intel i5", 2, 1, 1, 1 },
                    { 3, "Lenovo", "Intel i9", 3, 2, 3, 1 },
                    { 4, null, "AMD Ryzen 5", 4, 3, 1, 1 },
                    { 5, "Asus", "AMD Ryzen 7", 5, 3, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "ItemSales",
                columns: new[] { "Id", "Brand", "CPU", "ComputerId", "Quantity", "SaleId", "Status" },
                values: new object[,]
                {
                    { 1, "Dell", "Intel i7", 1, 1, 1, 2 },
                    { 2, "HP", "Intel i5", 2, 1, 1, 2 },
                    { 3, "Lenovo", "Intel i9", 3, 1, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemDonations_ComputerId",
                table: "ItemDonations",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDonations_DonationId",
                table: "ItemDonations",
                column: "DonationId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSales_ComputerId",
                table: "ItemSales",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSales_SaleId",
                table: "ItemSales",
                column: "SaleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemDonations");

            migrationBuilder.DropTable(
                name: "ItemSales");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "Sales");
        }
    }
}
