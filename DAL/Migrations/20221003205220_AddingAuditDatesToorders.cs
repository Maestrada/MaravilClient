using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddingAuditDatesToorders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Order",
                newName: "ModifiedOn");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Town",
                keyColumn: "Id",
                keyValue: 114,
                column: "Name",
                value: "El Tuma - La Dalia");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 10, 3, 14, 52, 19, 671, DateTimeKind.Local).AddTicks(8696), new DateTime(2022, 10, 3, 14, 52, 19, 671, DateTimeKind.Local).AddTicks(8708) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Order",
                newName: "OrderDate");

            migrationBuilder.UpdateData(
                table: "Town",
                keyColumn: "Id",
                keyValue: 114,
                column: "Name",
                value: "El Tuma -La Dalia");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 10, 3, 14, 24, 9, 570, DateTimeKind.Local).AddTicks(2661), new DateTime(2022, 10, 3, 14, 24, 9, 570, DateTimeKind.Local).AddTicks(2673) });
        }
    }
}
