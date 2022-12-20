using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebShopApp.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SubscriptionPackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Services",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timestamp",
                schema: "dbo",
                table: "PurchasedServices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "SubscriptionPackages",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NumberOfMonths = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionPackages_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "dbo",
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchasedSubscriptionPackages",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionPackageId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedSubscriptionPackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasedSubscriptionPackages_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "dbo",
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchasedSubscriptionPackages_SubscriptionPackages_SubscriptionPackageId",
                        column: x => x.SubscriptionPackageId,
                        principalSchema: "dbo",
                        principalTable: "SubscriptionPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f52a17a-ac3b-4989-906c-72f221069849", "AQAAAAEAACcQAAAAELXEYlCGQndEA+JW6tkdKaECQSa418eHik3WsB7c7tfD3wC7dvUgR6y/uY9eDr7n2A==", "15f4462e-a2a0-4697-a835-3b9d885bbcd1" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "SubscriptionPackages",
                columns: new[] { "Id", "CurrencyId", "Description", "IsActive", "NumberOfMonths", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Monthly Subscription", false, 1, 3.0 },
                    { 2, 1, "Monthly subscription for more than 6 months", false, 6, 2.0 },
                    { 3, 1, "Yearly subscription", false, 12, 30.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedSubscriptionPackages_CompanyId",
                schema: "dbo",
                table: "PurchasedSubscriptionPackages",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasedSubscriptionPackages_SubscriptionPackageId",
                schema: "dbo",
                table: "PurchasedSubscriptionPackages",
                column: "SubscriptionPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPackages_CurrencyId",
                schema: "dbo",
                table: "SubscriptionPackages",
                column: "CurrencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchasedSubscriptionPackages",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SubscriptionPackages",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                schema: "dbo",
                table: "PurchasedServices");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "060e148b-7a51-444b-a20e-4371a2d560a1", "AQAAAAEAACcQAAAAEFvrsLe18uejdAEH+7vKXmzMge4r7hI2PoJycVjMwz1/CD5qe3T0Mxg3A4BOip88bA==", "1f280abe-f9ef-4c6e-8663-1f88937ed3fb" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Services",
                columns: new[] { "Id", "Code", "CurrencyId", "Description", "Price", "ShowToUser", "WebShopId" },
                values: new object[,]
                {
                    { 1, "M_SUB", 1, "Monthly Subscription", 3.0, false, 1 },
                    { 2, "6M_SUB", 1, "Monthly subscription for more than 6 months", 2.0, false, 1 },
                    { 3, "12M_SUB", 1, "Yearly subscription", 30.0, false, 1 }
                });
        }
    }
}
