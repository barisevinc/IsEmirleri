using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsEmirleri.Data.Migrations
{
    /// <inheritdoc />
    public partial class falsetrue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 9, 23, 20, 4, 44, 985, DateTimeKind.Local).AddTicks(2373), new DateTime(2024, 9, 23, 20, 4, 44, 985, DateTimeKind.Local).AddTicks(2384), new DateTime(2024, 9, 23, 20, 4, 44, 985, DateTimeKind.Local).AddTicks(2384), new Guid("d4764e51-40ff-441d-b66b-21405e3227bf") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 9, 23, 20, 4, 44, 985, DateTimeKind.Local).AddTicks(2387), new DateTime(2024, 9, 23, 20, 4, 44, 985, DateTimeKind.Local).AddTicks(2388), new DateTime(2024, 9, 23, 20, 4, 44, 985, DateTimeKind.Local).AddTicks(2387), new Guid("cf462641-36d1-48d0-a0cf-cfb0952d880e") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 9, 23, 20, 4, 44, 985, DateTimeKind.Local).AddTicks(2389), new DateTime(2024, 9, 23, 20, 4, 44, 985, DateTimeKind.Local).AddTicks(2390), new DateTime(2024, 9, 23, 20, 4, 44, 985, DateTimeKind.Local).AddTicks(2389), new Guid("5b7516ed-e443-4c94-9f19-2f4497b802fb") });
        }
    }
}
