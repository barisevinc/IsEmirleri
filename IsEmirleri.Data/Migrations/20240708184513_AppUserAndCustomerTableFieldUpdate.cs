using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsEmirleri.Data.Migrations
{
    /// <inheritdoc />
    public partial class AppUserAndCustomerTableFieldUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 7, 8, 21, 45, 12, 312, DateTimeKind.Local).AddTicks(3216), new DateTime(2024, 7, 8, 21, 45, 12, 312, DateTimeKind.Local).AddTicks(3234), new DateTime(2024, 7, 8, 21, 45, 12, 312, DateTimeKind.Local).AddTicks(3233), new Guid("b3a4722f-7943-4f3a-adf1-1f3c68aefbdd") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 7, 8, 21, 45, 12, 312, DateTimeKind.Local).AddTicks(3242), new DateTime(2024, 7, 8, 21, 45, 12, 312, DateTimeKind.Local).AddTicks(3243), new DateTime(2024, 7, 8, 21, 45, 12, 312, DateTimeKind.Local).AddTicks(3243), new Guid("ac40f9a7-bcb7-48fa-b3fa-d4b668eb5b7a") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 7, 8, 21, 45, 12, 312, DateTimeKind.Local).AddTicks(3248), new DateTime(2024, 7, 8, 21, 45, 12, 312, DateTimeKind.Local).AddTicks(3249), new DateTime(2024, 7, 8, 21, 45, 12, 312, DateTimeKind.Local).AddTicks(3248), new Guid("151303cb-afb4-41f4-a9f6-4db10f1dd928") });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CustomerId",
                table: "Users",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Customers_CustomerId",
                table: "Users",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Customers_CustomerId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CustomerId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 7, 5, 19, 19, 25, 668, DateTimeKind.Local).AddTicks(8975), new DateTime(2024, 7, 5, 19, 19, 25, 668, DateTimeKind.Local).AddTicks(8985), new DateTime(2024, 7, 5, 19, 19, 25, 668, DateTimeKind.Local).AddTicks(8985), new Guid("cefb9367-d3cf-4f15-ab24-e19c3327f174") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 7, 5, 19, 19, 25, 668, DateTimeKind.Local).AddTicks(8987), new DateTime(2024, 7, 5, 19, 19, 25, 668, DateTimeKind.Local).AddTicks(8988), new DateTime(2024, 7, 5, 19, 19, 25, 668, DateTimeKind.Local).AddTicks(8988), new Guid("5e13b30f-cb98-409a-bd96-881de318edb0") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 7, 5, 19, 19, 25, 668, DateTimeKind.Local).AddTicks(8989), new DateTime(2024, 7, 5, 19, 19, 25, 668, DateTimeKind.Local).AddTicks(8990), new DateTime(2024, 7, 5, 19, 19, 25, 668, DateTimeKind.Local).AddTicks(8989), new Guid("11c325c3-be1e-413c-96f3-e17e0e8a1eaa") });
        }
    }
}
