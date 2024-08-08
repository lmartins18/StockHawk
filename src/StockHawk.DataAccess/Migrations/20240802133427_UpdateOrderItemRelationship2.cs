using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockHawk.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderItemRelationship2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6010), new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6010) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6020), new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6020) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6020), new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6030) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6160), new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6160) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6170), new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6170) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6240), new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6250), new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6250) });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5720), new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5810) });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5820), new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5820) });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5830), new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5830) });

            migrationBuilder.UpdateData(
                table: "OrderStatus",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5840), new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5840) });

            migrationBuilder.UpdateData(
                table: "OrderTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5980), new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5980) });

            migrationBuilder.UpdateData(
                table: "OrderTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5980), new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(5990) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6190), new DateTime(2024, 8, 1, 13, 34, 27, 343, DateTimeKind.Utc).AddTicks(6200), new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6200) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6210), new DateTime(2024, 8, 2, 13, 34, 27, 343, DateTimeKind.Utc).AddTicks(6220), new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6210) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6100), new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6110) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6120), new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6120) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6130), new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6130) });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6050), new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6060) });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6060), new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6070) });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6070), new DateTime(2024, 8, 2, 9, 34, 27, 343, DateTimeKind.Local).AddTicks(6070) });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

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

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8320), new DateTime(2024, 8, 2, 9, 25, 20, 362, DateTimeKind.Local).AddTicks(8320) });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
