using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsEmirleri.Data.Migrations
{
    /// <inheritdoc />
    public partial class pathh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 10, 11, 21, 34, 55, 159, DateTimeKind.Local).AddTicks(8522), new DateTime(2024, 10, 11, 21, 34, 55, 159, DateTimeKind.Local).AddTicks(8535), new DateTime(2024, 10, 11, 21, 34, 55, 159, DateTimeKind.Local).AddTicks(8534), new Guid("03294a67-1bce-4fe2-be87-bb226a58e32b") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 10, 11, 21, 34, 55, 159, DateTimeKind.Local).AddTicks(8536), new DateTime(2024, 10, 11, 21, 34, 55, 159, DateTimeKind.Local).AddTicks(8537), new DateTime(2024, 10, 11, 21, 34, 55, 159, DateTimeKind.Local).AddTicks(8537), new Guid("b7d490c0-f797-42e2-9531-1cdeb86af37d") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 10, 11, 21, 34, 55, 159, DateTimeKind.Local).AddTicks(8554), new DateTime(2024, 10, 11, 21, 34, 55, 159, DateTimeKind.Local).AddTicks(8555), new DateTime(2024, 10, 11, 21, 34, 55, 159, DateTimeKind.Local).AddTicks(8555), new Guid("477fb0d8-164d-4bd5-91a4-a544cd908797") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
