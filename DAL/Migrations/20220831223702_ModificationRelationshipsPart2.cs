using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class ModificationRelationshipsPart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_User_CreatedByUserId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_Client_User_UserId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_CreatedByUserId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_ModifiedByUserId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_UserId",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Client");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 31, 16, 37, 2, 486, DateTimeKind.Local).AddTicks(1804), new DateTime(2022, 8, 31, 16, 37, 2, 486, DateTimeKind.Local).AddTicks(1815) });

            migrationBuilder.CreateIndex(
                name: "IX_Client_CreatedByUserId",
                table: "Client",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_ModifiedByUserId",
                table: "Client",
                column: "ModifiedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_User_CreatedByUserId",
                table: "Client",
                column: "CreatedByUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Client_User_CreatedByUserId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_CreatedByUserId",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Client_ModifiedByUserId",
                table: "Client");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Client",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2022, 8, 31, 16, 32, 51, 365, DateTimeKind.Local).AddTicks(3369), new DateTime(2022, 8, 31, 16, 32, 51, 365, DateTimeKind.Local).AddTicks(3379) });

            migrationBuilder.CreateIndex(
                name: "IX_Client_CreatedByUserId",
                table: "Client",
                column: "CreatedByUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_ModifiedByUserId",
                table: "Client",
                column: "ModifiedByUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_UserId",
                table: "Client",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_User_CreatedByUserId",
                table: "Client",
                column: "CreatedByUserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Client_User_UserId",
                table: "Client",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
