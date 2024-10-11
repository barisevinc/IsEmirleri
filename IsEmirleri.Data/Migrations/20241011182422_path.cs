using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsEmirleri.Data.Migrations
{
    /// <inheritdoc />
    public partial class path : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 10, 11, 21, 24, 22, 37, DateTimeKind.Local).AddTicks(9122), new DateTime(2024, 10, 11, 21, 24, 22, 37, DateTimeKind.Local).AddTicks(9137), new DateTime(2024, 10, 11, 21, 24, 22, 37, DateTimeKind.Local).AddTicks(9137), new Guid("9d6c3443-da2c-4dd0-b25f-729d1e7b0d28") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 10, 11, 21, 24, 22, 37, DateTimeKind.Local).AddTicks(9139), new DateTime(2024, 10, 11, 21, 24, 22, 37, DateTimeKind.Local).AddTicks(9139), new DateTime(2024, 10, 11, 21, 24, 22, 37, DateTimeKind.Local).AddTicks(9139), new Guid("dac49681-58c4-4afe-be46-517d584691d3") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 10, 11, 21, 24, 22, 37, DateTimeKind.Local).AddTicks(9141), new DateTime(2024, 10, 11, 21, 24, 22, 37, DateTimeKind.Local).AddTicks(9141), new DateTime(2024, 10, 11, 21, 24, 22, 37, DateTimeKind.Local).AddTicks(9141), new Guid("5a102b46-7124-4d5d-aa91-641e0e1608db") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Projects");

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 10, 9, 19, 50, 13, 794, DateTimeKind.Local).AddTicks(5957), new DateTime(2024, 10, 9, 19, 50, 13, 794, DateTimeKind.Local).AddTicks(5967), new DateTime(2024, 10, 9, 19, 50, 13, 794, DateTimeKind.Local).AddTicks(5967), new Guid("97daa4ca-ea7a-4992-a83d-95fec5484d0a") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 10, 9, 19, 50, 13, 794, DateTimeKind.Local).AddTicks(5970), new DateTime(2024, 10, 9, 19, 50, 13, 794, DateTimeKind.Local).AddTicks(5971), new DateTime(2024, 10, 9, 19, 50, 13, 794, DateTimeKind.Local).AddTicks(5970), new Guid("3b3908e5-6cde-463f-b94e-a3f3ef768ca1") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 10, 9, 19, 50, 13, 794, DateTimeKind.Local).AddTicks(5972), new DateTime(2024, 10, 9, 19, 50, 13, 794, DateTimeKind.Local).AddTicks(5973), new DateTime(2024, 10, 9, 19, 50, 13, 794, DateTimeKind.Local).AddTicks(5973), new Guid("9cfceaf6-842d-48d5-a4d0-41ed0552bed7") });
        }
    }
}
