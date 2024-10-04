using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsEmirleri.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyAppUserPasswordHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 10, 3, 23, 48, 10, 208, DateTimeKind.Local).AddTicks(3869), new DateTime(2024, 10, 3, 23, 48, 10, 208, DateTimeKind.Local).AddTicks(3884), new DateTime(2024, 10, 3, 23, 48, 10, 208, DateTimeKind.Local).AddTicks(3884), new Guid("0f0ab414-16fb-4f1c-a684-bdc82e44d097") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 10, 3, 23, 48, 10, 208, DateTimeKind.Local).AddTicks(3888), new DateTime(2024, 10, 3, 23, 48, 10, 208, DateTimeKind.Local).AddTicks(3889), new DateTime(2024, 10, 3, 23, 48, 10, 208, DateTimeKind.Local).AddTicks(3888), new Guid("2f4f40e3-e1de-4237-9f26-39ed082d5040") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 10, 3, 23, 48, 10, 208, DateTimeKind.Local).AddTicks(3891), new DateTime(2024, 10, 3, 23, 48, 10, 208, DateTimeKind.Local).AddTicks(3892), new DateTime(2024, 10, 3, 23, 48, 10, 208, DateTimeKind.Local).AddTicks(3891), new Guid("cefd8173-267b-4415-8561-475ed3583a73") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 9, 23, 20, 8, 18, 691, DateTimeKind.Local).AddTicks(81), new DateTime(2024, 9, 23, 20, 8, 18, 691, DateTimeKind.Local).AddTicks(91), new DateTime(2024, 9, 23, 20, 8, 18, 691, DateTimeKind.Local).AddTicks(90), new Guid("54b93865-f75d-468b-9f2e-673ea625d41e") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 9, 23, 20, 8, 18, 691, DateTimeKind.Local).AddTicks(94), new DateTime(2024, 9, 23, 20, 8, 18, 691, DateTimeKind.Local).AddTicks(95), new DateTime(2024, 9, 23, 20, 8, 18, 691, DateTimeKind.Local).AddTicks(95), new Guid("59cbb65b-7941-49f0-bd01-a4bc8773e102") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 9, 23, 20, 8, 18, 691, DateTimeKind.Local).AddTicks(96), new DateTime(2024, 9, 23, 20, 8, 18, 691, DateTimeKind.Local).AddTicks(97), new DateTime(2024, 9, 23, 20, 8, 18, 691, DateTimeKind.Local).AddTicks(97), new Guid("e1e4bb40-7c44-4422-ad3d-a133c5090135") });
        }
    }
}
