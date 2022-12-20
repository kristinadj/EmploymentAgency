using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShopApp.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class IsActiveFlags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Services_Code_WebShopId",
                schema: "dbo",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Code",
                schema: "dbo",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "ShowToUser",
                schema: "dbo",
                table: "Services",
                newName: "IsActive");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99116b2f-882a-4650-9914-86a44f9e6af7", "AQAAAAEAACcQAAAAEJdUT5OObHd4whqWuzLI/04QiQkN/L4hs0aAqjjclqS+/A68YtW8LrCmh6wITegRUA==", "0fc639ee-ddb3-456e-90b1-fa6a37f121d4" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "SubscriptionPackages",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "SubscriptionPackages",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "SubscriptionPackages",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsActive",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                schema: "dbo",
                table: "Services",
                newName: "ShowToUser");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "dbo",
                table: "Services",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f52a17a-ac3b-4989-906c-72f221069849", "AQAAAAEAACcQAAAAELXEYlCGQndEA+JW6tkdKaECQSa418eHik3WsB7c7tfD3wC7dvUgR6y/uY9eDr7n2A==", "15f4462e-a2a0-4697-a835-3b9d885bbcd1" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Services",
                keyColumn: "Id",
                keyValue: 4,
                column: "Code",
                value: "S1");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Services",
                keyColumn: "Id",
                keyValue: 5,
                column: "Code",
                value: "S2");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Services",
                keyColumn: "Id",
                keyValue: 6,
                column: "Code",
                value: "S3");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Services",
                keyColumn: "Id",
                keyValue: 7,
                column: "Code",
                value: "S4");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "SubscriptionPackages",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "SubscriptionPackages",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "SubscriptionPackages",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsActive",
                value: false);

            migrationBuilder.CreateIndex(
                name: "IX_Services_Code_WebShopId",
                schema: "dbo",
                table: "Services",
                columns: new[] { "Code", "WebShopId" },
                unique: true);
        }
    }
}
