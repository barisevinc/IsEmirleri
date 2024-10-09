using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsEmirleri.Data.Migrations
{
    /// <inheritdoc />
    public partial class Raporlama : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StopWatch",
                table: "Tasks",
                newName: "MissionStartdate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedDate",
                table: "Tasks",
                type: "datetime2",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedDate",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "MissionStartdate",
                table: "Tasks",
                newName: "StopWatch");

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 10, 4, 15, 37, 49, 548, DateTimeKind.Local).AddTicks(7380), new DateTime(2024, 10, 4, 15, 37, 49, 548, DateTimeKind.Local).AddTicks(7424), new DateTime(2024, 10, 4, 15, 37, 49, 548, DateTimeKind.Local).AddTicks(7424), new Guid("294c8d02-1c44-4469-9d57-c2358929b934") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 10, 4, 15, 37, 49, 548, DateTimeKind.Local).AddTicks(7426), new DateTime(2024, 10, 4, 15, 37, 49, 548, DateTimeKind.Local).AddTicks(7427), new DateTime(2024, 10, 4, 15, 37, 49, 548, DateTimeKind.Local).AddTicks(7426), new Guid("4f3bfe0a-4bd9-40d2-be62-1e26dbb8116a") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 10, 4, 15, 37, 49, 548, DateTimeKind.Local).AddTicks(7428), new DateTime(2024, 10, 4, 15, 37, 49, 548, DateTimeKind.Local).AddTicks(7429), new DateTime(2024, 10, 4, 15, 37, 49, 548, DateTimeKind.Local).AddTicks(7428), new Guid("a8604e81-58f7-48ec-86e4-7209856c2afc") });
        }
    }
}
