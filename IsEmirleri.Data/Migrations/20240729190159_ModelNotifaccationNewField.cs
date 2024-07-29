using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsEmirleri.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModelNotifaccationNewField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_AppUserId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_AppUserId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Notifications");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Notifications");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Notifications",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 7, 29, 21, 39, 38, 539, DateTimeKind.Local).AddTicks(4057), new DateTime(2024, 7, 29, 21, 39, 38, 539, DateTimeKind.Local).AddTicks(4075), new DateTime(2024, 7, 29, 21, 39, 38, 539, DateTimeKind.Local).AddTicks(4074), new Guid("8b210727-4996-47f1-9b15-b2e9ade4ba77") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 7, 29, 21, 39, 38, 539, DateTimeKind.Local).AddTicks(4077), new DateTime(2024, 7, 29, 21, 39, 38, 539, DateTimeKind.Local).AddTicks(4078), new DateTime(2024, 7, 29, 21, 39, 38, 539, DateTimeKind.Local).AddTicks(4078), new Guid("d1fb83c3-17c8-43aa-a192-95cc6e697530") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 7, 29, 21, 39, 38, 539, DateTimeKind.Local).AddTicks(4080), new DateTime(2024, 7, 29, 21, 39, 38, 539, DateTimeKind.Local).AddTicks(4081), new DateTime(2024, 7, 29, 21, 39, 38, 539, DateTimeKind.Local).AddTicks(4081), new Guid("5dfdc600-06c2-44ab-a249-6244c0835639") });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_AppUserId",
                table: "Notifications",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_AppUserId",
                table: "Notifications",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
