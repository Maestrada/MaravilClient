using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class ModificationTableUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ActiveStatus",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSystemAdmin",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActiveStatus", "CreatedOn", "IsSystemAdmin", "ModifiedOn" },
                values: new object[] { true, new DateTime(2022, 9, 5, 15, 50, 33, 742, DateTimeKind.Local).AddTicks(4439), true, new DateTime(2022, 9, 5, 15, 50, 33, 742, DateTimeKind.Local).AddTicks(4452) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveStatus",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsSystemAdmin",
                table: "User");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 31, 16, 37, 2, 486, DateTimeKind.Local).AddTicks(1804), new DateTime(2022, 8, 31, 16, 37, 2, 486, DateTimeKind.Local).AddTicks(1815) });
        }
    }
}
