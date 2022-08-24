using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class defaulUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedOn", "ModifiedOn", "Password", "UserName" },
                values: new object[] { 1, new DateTime(2022, 8, 23, 20, 42, 10, 562, DateTimeKind.Local).AddTicks(6566), new DateTime(2022, 8, 23, 20, 42, 10, 562, DateTimeKind.Local).AddTicks(6575), "24a2a21b503d73db37ec36e1d81168f0", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
