using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockHawk.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatus_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Organization_OrganizationID",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderStatus",
                table: "OrderStatus");

            migrationBuilder.RenameTable(
                name: "OrderStatus",
                newName: "OrderStats");

            migrationBuilder.RenameColumn(
                name: "OrganizationID",
                table: "User",
                newName: "OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_User_OrganizationID",
                table: "User",
                newName: "IX_User_OrganizationId");

            migrationBuilder.RenameColumn(
                name: "SID",
                table: "Organization",
                newName: "SId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderStats",
                table: "OrderStats",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2590), "Electronic devices and gadgets", false, "Electronics", new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2590) },
                    { 2, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2600), "Appliances for home use", false, "Home Appliances", new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2600) },
                    { 3, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2600), "Books of various genres", false, "Books", new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2610) }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "PhoneNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "789 Customer Rd", new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2730), "john.doe@example.com", "John", false, "Doe", "555-1234", new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2730) },
                    { 2, "321 Customer Blvd", new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2740), "jane.smith@example.com", "Jane", false, "Smith", "555-5678", new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2740) }
                });

            migrationBuilder.InsertData(
                table: "OrderStats",
                columns: new[] { "Id", "CreatedAt", "Description", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2380), "Order is pending", false, "Pending", new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2380) },
                    { 2, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2390), "Order has been shipped", false, "Shipped", new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2390) },
                    { 3, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2390), "Order has been delivered", false, "Delivered", new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2400) },
                    { 4, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2400), "Order has been cancelled", false, "Cancelled", new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2400) }
                });

            migrationBuilder.InsertData(
                table: "OrderType",
                columns: new[] { "Id", "CreatedAt", "Description", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2430), "Retail order", false, "Retail", new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2440) },
                    { 2, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2440), "Wholesale order", false, "Wholesale", new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2440) }
                });

            migrationBuilder.InsertData(
                table: "Organization",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "SId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2190), false, "Organization One", "ORG001", new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2280) },
                    { 2, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2290), false, "Organization Two", "ORG002", new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2290) }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedAt", "Description", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2480), "Administrator role with full access", false, "Admin", new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2480) },
                    { 2, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2490), "Regular user role with limited access", false, "User", new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2490) }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Address", "ContactNumber", "CreatedAt", "Email", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "123 Supplier St", "1234567890", new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2630), "supplier1@example.com", false, "Supplier1", new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2640) },
                    { 2, "456 Supplier Ave", "0987654321", new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2640), "supplier2@example.com", false, "Supplier2", new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2640) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "IsDeleted", "OrderDate", "OrderStatusId", "OrderTypeId", "Reference", "ShippingCost", "TotalAmount", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2760), 1, false, new DateTime(2024, 7, 26, 19, 58, 40, 268, DateTimeKind.Utc).AddTicks(2770), 1, 1, "ORD001", 10.00m, 709.99m, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2760) },
                    { 2, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2780), 1, false, new DateTime(2024, 7, 27, 19, 58, 40, 268, DateTimeKind.Utc).AddTicks(2780), 1, 1, "ORD002", 15.00m, 515.00m, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2780) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "IsDeleted", "LowStockThreshold", "Name", "Price", "Quantity", "SupplierId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2670), "Latest model smartphone", false, 10, "Smartphone", 699.99m, 50, 1, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2670) },
                    { 2, 2, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2690), "High-efficiency washing machine", false, 5, "Washing Machine", 499.99m, 30, 2, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2690) },
                    { 3, 3, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2690), "Bestselling novel", false, 20, "Novel", 19.99m, 100, 2, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2700) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedAt", "DisplayName", "Email", "IsDeleted", "OrganizationId", "RoleId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2520), "admin man", "admin@example.com", false, 1, 1, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2520) },
                    { 2, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2530), "User man", "user@example.com", false, 1, 2, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2530) }
                });

            migrationBuilder.InsertData(
                table: "ActivityLogs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "IsDeleted", "OrderId", "ProductId", "Timestamp", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, "Created Order", new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2880), "Order with reference ORD001 created", false, 1, null, new DateTime(2024, 7, 27, 19, 58, 40, 268, DateTimeKind.Utc).AddTicks(2880), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2880), 1 },
                    { 2, "Updated Order", new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2890), "Order with reference ORD002 updated", false, 1, null, new DateTime(2024, 7, 27, 19, 58, 40, 268, DateTimeKind.Utc).AddTicks(2900), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2890), 1 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "CreatedAt", "DiscountAmount", "IsDeleted", "OrderId", "ProductId", "Quantity", "TotalAmount", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2830), 0.00m, false, 1, 1, 1, 699.99m, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2840) },
                    { 2, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2840), 0.00m, false, 1, 1, 1, 499.99m, new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2840) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStats_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId",
                principalTable: "OrderStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Organization_OrganizationId",
                table: "User",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStats_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Organization_OrganizationId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderStats",
                table: "OrderStats");

            migrationBuilder.DeleteData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderStats",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderStats",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderStats",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Organization",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderStats",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organization",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "OrderStats",
                newName: "OrderStatus");

            migrationBuilder.RenameColumn(
                name: "OrganizationId",
                table: "User",
                newName: "OrganizationID");

            migrationBuilder.RenameIndex(
                name: "IX_User_OrganizationId",
                table: "User",
                newName: "IX_User_OrganizationID");

            migrationBuilder.RenameColumn(
                name: "SId",
                table: "Organization",
                newName: "SID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderStatus",
                table: "OrderStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatus_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId",
                principalTable: "OrderStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Organization_OrganizationID",
                table: "User",
                column: "OrganizationID",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
