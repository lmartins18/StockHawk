using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StockHawk.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRoleUserOrganizationAndActivityLogFromData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLogs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Roles");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityLogs_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ActivityLogs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActivityLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "CreatedAt", "IsDeleted", "Name", "SId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9110), false, "Organization One", "ORG001", new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9190) },
                    { 2, new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9200), false, "Organization Two", "ORG002", new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9210) }
                });

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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "Description", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9560), "Administrator role with full access", false, "Admin", new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9560) },
                    { 2, new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9570), "Regular user role with limited access", false, "User", new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9570) }
                });

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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DisplayName", "Email", "IsDeleted", "OrganizationId", "RoleId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9600), "admin man", "admin@example.com", false, 1, 1, new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9600) },
                    { 2, new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9600), "User man", "user@example.com", false, 1, 2, new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9610) }
                });

            migrationBuilder.InsertData(
                table: "ActivityLogs",
                columns: new[] { "Id", "Action", "CreatedAt", "Details", "IsDeleted", "OrderId", "ProductId", "Timestamp", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, "Created Order", new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9880), "Order with reference ORD001 created", false, 1, null, new DateTime(2024, 7, 28, 23, 0, 38, 113, DateTimeKind.Utc).AddTicks(9890), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9890), 1 },
                    { 2, "Updated Order", new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9890), "Order with reference ORD002 updated", false, 1, null, new DateTime(2024, 7, 28, 23, 0, 38, 113, DateTimeKind.Utc).AddTicks(9900), new DateTime(2024, 7, 28, 19, 0, 38, 113, DateTimeKind.Local).AddTicks(9900), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_OrderId",
                table: "ActivityLogs",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_ProductId",
                table: "ActivityLogs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_UserId",
                table: "ActivityLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationId",
                table: "Users",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }
    }
}
