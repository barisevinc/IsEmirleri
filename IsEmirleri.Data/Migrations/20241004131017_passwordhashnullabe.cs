using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsEmirleri.Data.Migrations
{
    /// <inheritdoc />
    public partial class passwordhashnullabe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 10, 4, 16, 10, 17, 119, DateTimeKind.Local).AddTicks(9425), new DateTime(2024, 10, 4, 16, 10, 17, 119, DateTimeKind.Local).AddTicks(9435), new DateTime(2024, 10, 4, 16, 10, 17, 119, DateTimeKind.Local).AddTicks(9434), new Guid("2c04751b-50c3-4ee6-b933-8d25dad34b2a") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 10, 4, 16, 10, 17, 119, DateTimeKind.Local).AddTicks(9442), new DateTime(2024, 10, 4, 16, 10, 17, 119, DateTimeKind.Local).AddTicks(9443), new DateTime(2024, 10, 4, 16, 10, 17, 119, DateTimeKind.Local).AddTicks(9442), new Guid("8115616e-8db4-4ea3-9dc2-4fdf9e3d2a45") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 10, 4, 16, 10, 17, 119, DateTimeKind.Local).AddTicks(9444), new DateTime(2024, 10, 4, 16, 10, 17, 119, DateTimeKind.Local).AddTicks(9445), new DateTime(2024, 10, 4, 16, 10, 17, 119, DateTimeKind.Local).AddTicks(9445), new Guid("7a00eb57-d5ec-4920-90b6-c2b5a0f44dfc") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
