using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IsEmirleri.Data.Migrations
{
    /// <inheritdoc />
    public partial class newModelNotifaccationAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

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
        }
    }
}
