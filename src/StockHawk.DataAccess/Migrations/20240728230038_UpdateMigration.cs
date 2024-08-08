using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockHawk.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Timestamp", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9880), new DateTime(2024, 7, 28, 23, 0, 38, 113, DateTimeKind.Utc).AddTicks(9890), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9890) });

            migrationBuilder.UpdateData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Timestamp", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9890), new DateTime(2024, 7, 28, 23, 0, 38, 113, DateTimeKind.Utc).AddTicks(9900), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9900) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9630), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9640) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9640), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9640) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9650), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9650) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9760), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9760) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9760), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9770) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9840), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9840) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9850), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9850) });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9470), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9470) });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9480), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9480) });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9480), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9480) });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9490), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9490) });

            migrationBuilder.UpdateData(
                table: "OrderTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9520), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9520) });

            migrationBuilder.UpdateData(
                table: "OrderTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9530), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9530) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9790), new DateTime(2024, 7, 27, 23, 0, 38, 113, DateTimeKind.Utc).AddTicks(9800), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9790) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9810), new DateTime(2024, 7, 28, 23, 0, 38, 113, DateTimeKind.Utc).AddTicks(9820), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9820) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9110), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9190) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9200), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9210) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9710), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9710) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9720), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9720) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9730), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9730) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9560), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9560) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9570), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9570) });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9670), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9670) });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9680), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9680) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9600), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9600) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9600), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9610) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Timestamp", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1790), new DateTime(2024, 7, 28, 12, 29, 56, 49, DateTimeKind.Utc).AddTicks(1790), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1790) });

            migrationBuilder.UpdateData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Timestamp", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1800), new DateTime(2024, 7, 28, 12, 29, 56, 49, DateTimeKind.Utc).AddTicks(1800), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1800) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1500), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1510) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1510), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1520) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1520), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1520) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1660), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1660) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1670), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1670) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1740), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1740) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1750), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1750) });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1290), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1290) });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1290), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1300), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1300) });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1310), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1310) });

            migrationBuilder.UpdateData(
                table: "OrderTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1340), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1350) });

            migrationBuilder.UpdateData(
                table: "OrderTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1350), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1350) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1700), new DateTime(2024, 7, 27, 12, 29, 56, 49, DateTimeKind.Utc).AddTicks(1700), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1700) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1710), new DateTime(2024, 7, 28, 12, 29, 56, 49, DateTimeKind.Utc).AddTicks(1720), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1710) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1060), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1130) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1140), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1140) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1600), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1600) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1610), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1610) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1620), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1620) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1390), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1400), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1400) });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1550), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1560) });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1560), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1560) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1430), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1430) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1440), new DateTime(2024, 7, 28, 8, 29, 56, 49, DateTimeKind.Local).AddTicks(1440) });
        }
    }
}
