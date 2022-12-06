using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentServiceProvider.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedWebShop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentServices",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "PaymentTypeServices",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypeServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebShops",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TransactionSuccessWebhook = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TransactionFailureWebhook = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TransactionErrorWebhook = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ParentWebShopId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebShops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebShops_WebShops_ParentWebShopId",
                        column: x => x.ParentWebShopId,
                        principalSchema: "dbo",
                        principalTable: "WebShops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupportedPaymentTypeServices",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebShopId = table.Column<int>(type: "int", nullable: false),
                    PaymentTypeServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportedPaymentTypeServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportedPaymentTypeServices_PaymentTypeServices_PaymentTypeServiceId",
                        column: x => x.PaymentTypeServiceId,
                        principalSchema: "dbo",
                        principalTable: "PaymentTypeServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportedPaymentTypeServices_WebShops_WebShopId",
                        column: x => x.WebShopId,
                        principalSchema: "dbo",
                        principalTable: "WebShops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypeServices_Name",
                schema: "dbo",
                table: "PaymentTypeServices",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupportedPaymentTypeServices_PaymentTypeServiceId",
                schema: "dbo",
                table: "SupportedPaymentTypeServices",
                column: "PaymentTypeServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportedPaymentTypeServices_WebShopId_PaymentTypeServiceId",
                schema: "dbo",
                table: "SupportedPaymentTypeServices",
                columns: new[] { "WebShopId", "PaymentTypeServiceId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WebShops_Name",
                schema: "dbo",
                table: "WebShops",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WebShops_ParentWebShopId",
                schema: "dbo",
                table: "WebShops",
                column: "ParentWebShopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupportedPaymentTypeServices",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PaymentTypeServices",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WebShops",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "PaymentServices",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentServices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentServices_Name",
                schema: "dbo",
                table: "PaymentServices",
                column: "Name",
                unique: true);
        }
    }
}
