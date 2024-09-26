using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsEmirleri.Data.Migrations
{
    /// <inheritdoc />
    public partial class MissionAddPropertyEndTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TotalDuration",
                table: "Tasks",
                type: "time",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Tasks",
                type: "datetime2",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Tasks");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TotalDuration",
                table: "Tasks",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

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
    }
}
