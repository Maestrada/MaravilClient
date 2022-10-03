using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddReferenceToClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 10, 1, 17, 14, 39, 334, DateTimeKind.Local).AddTicks(5615), new DateTime(2022, 10, 1, 17, 14, 39, 334, DateTimeKind.Local).AddTicks(5637) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Client");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 9, 20, 17, 41, 2, 666, DateTimeKind.Local).AddTicks(7026), new DateTime(2022, 9, 20, 17, 41, 2, 666, DateTimeKind.Local).AddTicks(7035) });
        }
    }
}
