using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Electronics", "Electronic devices" },
                    { 2, "Clothing", "Fashion and clothing" }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "InvoiceDate", "OrderId", "TotalAmount" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 14, 16, 42, 45, 711, DateTimeKind.Local).AddTicks(695), 1, 400m },
                    { 2, new DateTime(2025, 1, 13, 16, 42, 45, 711, DateTimeKind.Local).AddTicks(697), 2, 1100m }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderId", "ProductId", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 400m, 1 },
                    { 2, 2, 1100m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "OrderDate", "Status", "TotalAmount", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 14, 16, 42, 45, 711, DateTimeKind.Local).AddTicks(630), 0, 400m, 1 },
                    { 2, new DateTime(2025, 1, 13, 16, 42, 45, 711, DateTimeKind.Local).AddTicks(645), 1, 1100m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ImagePath", "NewPrice", "OldPrice", "ProductDescription", "ProductName", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, "/images/smartphone.jpg", 400m, 500m, "Latest model smartphone", "Smartphone", 100 },
                    { 2, 1, "/images/laptop.jpg", 1100m, 1200m, "High-performance laptop", "Laptop", 50 },
                    { 3, 2, "/images/tshirt.jpg", 15m, 20m, "Cotton t-shirt", "T-shirt", 200 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "EmailAddress", "FullName", "PasswordHash", "Phone", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, null, "john.doe@example.com", "John Doe", "password123", null, 0, "johndoe" },
                    { 2, null, "jane.smith@example.com", "Jane Smith", "password123", null, 1, "janesmith" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);
        }
    }
}
