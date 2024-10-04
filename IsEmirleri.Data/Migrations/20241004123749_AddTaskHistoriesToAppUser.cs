using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsEmirleri.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTaskHistoriesToAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
