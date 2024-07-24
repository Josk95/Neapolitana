using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Neapolitana.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedCouponTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "Code", "Discount", "MinimumAmount" },
                values: new object[,]
                {
                    { 1, "10OFF", 10.0, 20 },
                    { 2, "20OFF", 20.0, 20 },
                    { 3, "20OFF", 20.0, 20 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
