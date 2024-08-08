using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockHawk.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLogs_User_UserId",
                table: "ActivityLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStats_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderType_OrderTypeId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Organization_OrganizationId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organization",
                table: "Organization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderType",
                table: "OrderType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderStats",
                table: "OrderStats");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Organization",
                newName: "Organizations");

            migrationBuilder.RenameTable(
                name: "OrderType",
                newName: "OrderTypes");

            migrationBuilder.RenameTable(
                name: "OrderStats",
                newName: "OrderStatus");

            migrationBuilder.RenameIndex(
                name: "IX_User_RoleId",
                table: "Users",
                newName: "IX_Users_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_User_OrganizationId",
                table: "Users",
                newName: "IX_Users_OrganizationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderTypes",
                table: "OrderTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderStatus",
                table: "OrderStatus",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLogs_Users_UserId",
                table: "ActivityLogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatus_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId",
                principalTable: "OrderStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderTypes_OrderTypeId",
                table: "Orders",
                column: "OrderTypeId",
                principalTable: "OrderTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                table: "Users",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLogs_Users_UserId",
                table: "ActivityLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStatus_OrderStatusId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderTypes_OrderTypeId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organizations_OrganizationId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderTypes",
                table: "OrderTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderStatus",
                table: "OrderStatus");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "Organizations",
                newName: "Organization");

            migrationBuilder.RenameTable(
                name: "OrderTypes",
                newName: "OrderType");

            migrationBuilder.RenameTable(
                name: "OrderStatus",
                newName: "OrderStats");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RoleId",
                table: "User",
                newName: "IX_User_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_OrganizationId",
                table: "User",
                newName: "IX_User_OrganizationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organization",
                table: "Organization",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderType",
                table: "OrderType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderStats",
                table: "OrderStats",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Timestamp", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2880), new DateTime(2024, 7, 27, 19, 58, 40, 268, DateTimeKind.Utc).AddTicks(2880), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2880) });

            migrationBuilder.UpdateData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Timestamp", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2890), new DateTime(2024, 7, 27, 19, 58, 40, 268, DateTimeKind.Utc).AddTicks(2900), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2890) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2590), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2590) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2600), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2600) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2600), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2610) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2730), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2730) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2740), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2740) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2830), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2840) });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2840), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2840) });

            migrationBuilder.UpdateData(
                table: "OrderStats",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2380), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2380) });

            migrationBuilder.UpdateData(
                table: "OrderStats",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2390), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2390) });

            migrationBuilder.UpdateData(
                table: "OrderStats",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2390), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2400) });

            migrationBuilder.UpdateData(
                table: "OrderStats",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2400), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2400) });

            migrationBuilder.UpdateData(
                table: "OrderType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2430), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2440) });

            migrationBuilder.UpdateData(
                table: "OrderType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2440), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2440) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2760), new DateTime(2024, 7, 26, 19, 58, 40, 268, DateTimeKind.Utc).AddTicks(2770), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2760) });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2780), new DateTime(2024, 7, 27, 19, 58, 40, 268, DateTimeKind.Utc).AddTicks(2780), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2780) });

            migrationBuilder.UpdateData(
                table: "Organization",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2190), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2280) });

            migrationBuilder.UpdateData(
                table: "Organization",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2290), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2290) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2670), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2670) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2690), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2690) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2690), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2700) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2480), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2480) });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2490), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2490) });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2630), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2640) });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2640), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2640) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2520), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2520) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2530), new DateTime(2024, 7, 27, 15, 58, 40, 268, DateTimeKind.Local).AddTicks(2530) });

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLogs_User_UserId",
                table: "ActivityLogs",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStats_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId",
                principalTable: "OrderStats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderType_OrderTypeId",
                table: "Orders",
                column: "OrderTypeId",
                principalTable: "OrderType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Organization_OrganizationId",
                table: "User",
                column: "OrganizationId",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
