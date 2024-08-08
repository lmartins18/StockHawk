using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockHawk.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderItemRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8180), new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8180) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8190), new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8190) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8200), new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8200) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8430), new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8440) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8450), new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8450) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8540), new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8550) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8560), new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8560) });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(7820), new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(7920) });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(7930), new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(7930) });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(7940), new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(7940) });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(7950), new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(7950) });

            migrationBuilder.UpdateData(
                table: "OrderTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8130), new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8140) });

            migrationBuilder.UpdateData(
                table: "OrderTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8140), new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8140) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8490), new DateTime(2024, 8, 1, 13, 25, 20, 362, DateTimeKind.Utc).AddTicks(8490), new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8490) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8510), new DateTime(2024, 8, 2, 13, 25, 20, 362, DateTimeKind.Utc).AddTicks(8510), new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8510) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8360), new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8370) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8380), new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8390) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8390), new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8390) });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8300), new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8300) });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8310), new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8310) });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "ContactNumber", "CreatedAt", "Email", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[] { 3, "322 Supplier Ave", "123123123", new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8320), "supplier3@example.com", false, "Empty supplier", new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8320) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7320), new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7320) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7320), new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7320) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7330), new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7330) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7400), new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7400) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7410), new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7410) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7460), new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7460) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7470), new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7470) });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7130), new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7200) });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7200), new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7210), new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7210), new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "OrderTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7300), new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7300) });

            migrationBuilder.UpdateData(
                table: "OrderTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7300), new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7300) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7430), new DateTime(2024, 7, 28, 23, 24, 7, 410, DateTimeKind.Utc).AddTicks(7430), new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7430) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7440), new DateTime(2024, 7, 29, 23, 24, 7, 410, DateTimeKind.Utc).AddTicks(7450), new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7440) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7370), new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7370) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7380), new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7380) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7380), new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7380) });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7340), new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7350) });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7350), new DateTime(2024, 7, 29, 19, 24, 7, 410, DateTimeKind.Local).AddTicks(7350) });
        }
    }
}
