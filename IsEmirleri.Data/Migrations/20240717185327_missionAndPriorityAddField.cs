using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsEmirleri.Data.Migrations
{
    /// <inheritdoc />
    public partial class missionAndPriorityAddField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriorityId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 7, 17, 21, 53, 26, 641, DateTimeKind.Local).AddTicks(8165), new DateTime(2024, 7, 17, 21, 53, 26, 641, DateTimeKind.Local).AddTicks(8182), new DateTime(2024, 7, 17, 21, 53, 26, 641, DateTimeKind.Local).AddTicks(8181), new Guid("d874f59d-5772-4ed1-803f-e99c53357397") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 7, 17, 21, 53, 26, 641, DateTimeKind.Local).AddTicks(8186), new DateTime(2024, 7, 17, 21, 53, 26, 641, DateTimeKind.Local).AddTicks(8187), new DateTime(2024, 7, 17, 21, 53, 26, 641, DateTimeKind.Local).AddTicks(8186), new Guid("60e5b455-214e-4997-a0f5-73581843085f") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 7, 17, 21, 53, 26, 641, DateTimeKind.Local).AddTicks(8189), new DateTime(2024, 7, 17, 21, 53, 26, 641, DateTimeKind.Local).AddTicks(8190), new DateTime(2024, 7, 17, 21, 53, 26, 641, DateTimeKind.Local).AddTicks(8189), new Guid("468bf18e-25dd-4e5c-8568-c2c6cb5e3833") });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_PriorityId",
                table: "Tasks",
                column: "PriorityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Priorities_PriorityId",
                table: "Tasks",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Priorities_PriorityId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_PriorityId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "PriorityId",
                table: "Tasks");

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 7, 13, 13, 59, 39, 861, DateTimeKind.Local).AddTicks(6327), new DateTime(2024, 7, 13, 13, 59, 39, 861, DateTimeKind.Local).AddTicks(6342), new DateTime(2024, 7, 13, 13, 59, 39, 861, DateTimeKind.Local).AddTicks(6341), new Guid("fc901be9-8ad9-4b3d-9e82-8d6e3a80b068") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 7, 13, 13, 59, 39, 861, DateTimeKind.Local).AddTicks(6365), new DateTime(2024, 7, 13, 13, 59, 39, 861, DateTimeKind.Local).AddTicks(6365), new DateTime(2024, 7, 13, 13, 59, 39, 861, DateTimeKind.Local).AddTicks(6365), new Guid("66482fd9-e0a7-4578-9aeb-5daf80ae025a") });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "DateDeleted", "DateUpdated", "Guid" },
                values: new object[] { new DateTime(2024, 7, 13, 13, 59, 39, 861, DateTimeKind.Local).AddTicks(6368), new DateTime(2024, 7, 13, 13, 59, 39, 861, DateTimeKind.Local).AddTicks(6369), new DateTime(2024, 7, 13, 13, 59, 39, 861, DateTimeKind.Local).AddTicks(6368), new Guid("b0de142e-b59d-4f5c-bef2-0c3615f5f3c5") });
        }
    }
}
