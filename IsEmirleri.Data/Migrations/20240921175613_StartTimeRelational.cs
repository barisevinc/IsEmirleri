using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsEmirleri.Data.Migrations
{
    /// <inheritdoc />
    public partial class StartTimeRelational : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Tasks",
                newName: "TotalDuration");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 9, 21, 20, 56, 13, 258, DateTimeKind.Local).AddTicks(6651), new DateTime(2024, 9, 21, 20, 56, 13, 258, DateTimeKind.Local).AddTicks(6664), new DateTime(2024, 9, 21, 20, 56, 13, 258, DateTimeKind.Local).AddTicks(6663), new Guid("4681d24f-8d28-46a0-9c7b-27a4c37ac9b7") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 9, 21, 20, 56, 13, 258, DateTimeKind.Local).AddTicks(6674), new DateTime(2024, 9, 21, 20, 56, 13, 258, DateTimeKind.Local).AddTicks(6675), new DateTime(2024, 9, 21, 20, 56, 13, 258, DateTimeKind.Local).AddTicks(6674), new Guid("7128ee4c-b086-46d5-84f7-0ec16a725c4d") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 9, 21, 20, 56, 13, 258, DateTimeKind.Local).AddTicks(6677), new DateTime(2024, 9, 21, 20, 56, 13, 258, DateTimeKind.Local).AddTicks(6678), new DateTime(2024, 9, 21, 20, 56, 13, 258, DateTimeKind.Local).AddTicks(6677), new Guid("6f2b84a9-bea0-4f6b-a2d3-f7dccede8662") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "TotalDuration",
                table: "Tasks",
                newName: "Duration");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Tasks",
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
                values: new object[] { new DateTime(2024, 7, 29, 22, 1, 57, 810, DateTimeKind.Local).AddTicks(6061), new DateTime(2024, 7, 29, 22, 1, 57, 810, DateTimeKind.Local).AddTicks(6080), new DateTime(2024, 7, 29, 22, 1, 57, 810, DateTimeKind.Local).AddTicks(6080), new Guid("e924e9f8-fa16-4006-bde3-c52da4caa037") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 7, 29, 22, 1, 57, 810, DateTimeKind.Local).AddTicks(6085), new DateTime(2024, 7, 29, 22, 1, 57, 810, DateTimeKind.Local).AddTicks(6086), new DateTime(2024, 7, 29, 22, 1, 57, 810, DateTimeKind.Local).AddTicks(6086), new Guid("e57d7bfc-518a-497d-8790-926fb2a8f055") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 7, 29, 22, 1, 57, 810, DateTimeKind.Local).AddTicks(6088), new DateTime(2024, 7, 29, 22, 1, 57, 810, DateTimeKind.Local).AddTicks(6089), new DateTime(2024, 7, 29, 22, 1, 57, 810, DateTimeKind.Local).AddTicks(6089), new Guid("f14fbdd9-4a6f-4a89-b34d-21e6fbf22294") });
        }
    }
}
