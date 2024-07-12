using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsEmirleri.Data.Migrations
{
    /// <inheritdoc />
    public partial class userModelAddFieldPicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
