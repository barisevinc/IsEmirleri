using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsEmirleri.Data.Migrations
{
    /// <inheritdoc />
    public partial class addField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 7, 13, 13, 59, 39, 861, DateTimeKind.Local).AddTicks(6327), new DateTime(2024, 7, 13, 13, 59, 39, 861, DateTimeKind.Local).AddTicks(6342), new DateTime(2024, 7, 13, 13, 59, 39, 861, DateTimeKind.Local).AddTicks(6341), new Guid("fc901be9-8ad9-4b3d-9e82-8d6e3a80b068") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 7, 13, 13, 59, 39, 861, DateTimeKind.Local).AddTicks(6365), new DateTime(2024, 7, 13, 13, 59, 39, 861, DateTimeKind.Local).AddTicks(6365), new DateTime(2024, 7, 13, 13, 59, 39, 861, DateTimeKind.Local).AddTicks(6365), new Guid("66482fd9-e0a7-4578-9aeb-5daf80ae025a") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 7, 13, 13, 59, 39, 861, DateTimeKind.Local).AddTicks(6368), new DateTime(2024, 7, 13, 13, 59, 39, 861, DateTimeKind.Local).AddTicks(6369), new DateTime(2024, 7, 13, 13, 59, 39, 861, DateTimeKind.Local).AddTicks(6368), new Guid("b0de142e-b59d-4f5c-bef2-0c3615f5f3c5") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 7, 12, 22, 1, 30, 827, DateTimeKind.Local).AddTicks(445), new DateTime(2024, 7, 12, 22, 1, 30, 827, DateTimeKind.Local).AddTicks(460), new DateTime(2024, 7, 12, 22, 1, 30, 827, DateTimeKind.Local).AddTicks(459), new Guid("57ca3829-d1df-4c72-af37-1c0d6f53baf9") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 7, 12, 22, 1, 30, 827, DateTimeKind.Local).AddTicks(464), new DateTime(2024, 7, 12, 22, 1, 30, 827, DateTimeKind.Local).AddTicks(465), new DateTime(2024, 7, 12, 22, 1, 30, 827, DateTimeKind.Local).AddTicks(465), new Guid("78557c7e-a798-4b15-9d71-c5a428a03107") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 7, 12, 22, 1, 30, 827, DateTimeKind.Local).AddTicks(467), new DateTime(2024, 7, 12, 22, 1, 30, 827, DateTimeKind.Local).AddTicks(468), new DateTime(2024, 7, 12, 22, 1, 30, 827, DateTimeKind.Local).AddTicks(467), new Guid("dbafa1c4-05f7-42bd-b9ce-11752cf6716b") });
        }
    }
}
