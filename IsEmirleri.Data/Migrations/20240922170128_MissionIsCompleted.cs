using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsEmirleri.Data.Migrations
{
    /// <inheritdoc />
    public partial class MissionIsCompleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 9, 22, 20, 1, 27, 588, DateTimeKind.Local).AddTicks(136), new DateTime(2024, 9, 22, 20, 1, 27, 588, DateTimeKind.Local).AddTicks(145), new DateTime(2024, 9, 22, 20, 1, 27, 588, DateTimeKind.Local).AddTicks(144), new Guid("f877766e-aece-477c-bc22-623d2facfd85") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 9, 22, 20, 1, 27, 588, DateTimeKind.Local).AddTicks(156), new DateTime(2024, 9, 22, 20, 1, 27, 588, DateTimeKind.Local).AddTicks(156), new DateTime(2024, 9, 22, 20, 1, 27, 588, DateTimeKind.Local).AddTicks(156), new Guid("6a4ce9a5-7552-4926-a427-9db827c963e1") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 9, 22, 20, 1, 27, 588, DateTimeKind.Local).AddTicks(159), new DateTime(2024, 9, 22, 20, 1, 27, 588, DateTimeKind.Local).AddTicks(159), new DateTime(2024, 9, 22, 20, 1, 27, 588, DateTimeKind.Local).AddTicks(159), new Guid("f1f57240-bcee-433a-839a-0f44d0ed645e") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Tasks");

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
    }
}
