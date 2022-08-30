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
                values: new object[] { 1, new DateTime(2022, 8, 23, 20, 42, 10, 562, DateTimeKind.Local).AddTicks(6566), new DateTime(2022, 8, 23, 20, 42, 10, 562, DateTimeKind.Local).AddTicks(6575), "bca6062db9ffe0bdb13f01b5dc48f6e0e7d0f8c8a21af0324c9971d3fbd51e08", "admin" });
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
