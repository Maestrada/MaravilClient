using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class MainMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSystemAdmin = table.Column<bool>(type: "bit", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Town",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Town", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Town_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CellPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CellPhone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    ModifiedByUserId = table.Column<int>(type: "int", nullable: false),
                    TownId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_Town_TownId",
                        column: x => x.TownId,
                        principalTable: "Town",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_User_ModifiedByUserId",
                        column: x => x.ModifiedByUserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Boaco" },
                    { 2, "Carazo" },
                    { 3, "Chinandega" },
                    { 4, "Chontales" },
                    { 5, "Costa Caribe Norte" },
                    { 6, "Costa Caribe Sur" },
                    { 7, "Estelí" },
                    { 8, "Granada" },
                    { 9, "Jinotega" },
                    { 10, "León" },
                    { 11, "Madriz" },
                    { 12, "Managua" },
                    { 13, "Masaya" },
                    { 14, "Matagalpa" },
                    { 15, "Nueva Segovia" },
                    { 16, "Río San Juan" },
                    { 17, "Rivas" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "ActiveStatus", "CreatedOn", "IsSystemAdmin", "ModifiedOn", "Password", "UserName" },
                values: new object[] { 1, true, new DateTime(2022, 9, 20, 17, 41, 2, 666, DateTimeKind.Local).AddTicks(7026), true, new DateTime(2022, 9, 20, 17, 41, 2, 666, DateTimeKind.Local).AddTicks(7035), "bca6062db9ffe0bdb13f01b5dc48f6e0e7d0f8c8a21af0324c9971d3fbd51e08", "admin" });

            migrationBuilder.InsertData(
                table: "Town",
                columns: new[] { "Id", "Name", "StateId" },
                values: new object[,]
                {
                    { 1, "Boaco", 1 },
                    { 2, "Camoapa", 1 },
                    { 3, "San José de los Remates", 1 },
                    { 4, "San Lorenzo", 1 },
                    { 5, "Santa Lucía", 1 },
                    { 6, "Teustepe", 1 },
                    { 7, "Diriamba", 2 },
                    { 8, "Dolores", 2 },
                    { 9, "El Rosario", 2 },
                    { 10, "Jinotepe", 2 },
                    { 11, "La Conquista", 2 },
                    { 12, "La Paz de Oriente", 2 },
                    { 13, "San Marcos", 2 },
                    { 14, "Santa Teresa", 2 },
                    { 15, "Chichigalpa", 3 },
                    { 16, "Chinandega", 3 },
                    { 17, "Cinco Pinos", 3 },
                    { 18, "Corinto", 3 },
                    { 19, "El Realejo", 3 },
                    { 20, "El Viejo", 3 },
                    { 21, "Posoltega", 3 },
                    { 22, "Puerto Morazán", 3 },
                    { 23, "San Francisco del Norte", 3 },
                    { 24, "San Pedro del Norte", 3 },
                    { 25, "Santo Tomás del Norte", 3 },
                    { 26, "Somotillo", 3 },
                    { 27, "Villanueva", 3 },
                    { 28, "Acoyapa", 4 },
                    { 29, "Comalapa", 4 },
                    { 30, "Cuapa", 4 },
                    { 31, "El Coral", 4 },
                    { 32, "Juigalpa", 4 },
                    { 33, "La Libertad", 4 },
                    { 34, "San Pedro de Lóvago", 4 },
                    { 35, "Santo Domingo", 4 },
                    { 36, "Santo Tomás", 4 },
                    { 37, "Villa Sandino", 4 },
                    { 38, "Bonanza", 5 },
                    { 39, "Mulukukú", 5 },
                    { 40, "Prinzapolka", 5 },
                    { 41, "Puerto Cabezas", 5 },
                    { 42, "Rosita", 5 }
                });

            migrationBuilder.InsertData(
                table: "Town",
                columns: new[] { "Id", "Name", "StateId" },
                values: new object[,]
                {
                    { 43, "Siuna", 5 },
                    { 44, "Waslala", 5 },
                    { 45, "Waspán", 5 },
                    { 46, "Bluefields", 6 },
                    { 47, "Corn Island", 6 },
                    { 48, "Desembocadura de Río Grande", 6 },
                    { 49, "El Ayote", 6 },
                    { 50, "El Rama", 6 },
                    { 51, "El Tortuguero", 6 },
                    { 52, "Kukra Hill", 6 },
                    { 53, "La Cruz de Río Grande", 6 },
                    { 54, "Laguna de Perlas", 6 },
                    { 55, "Muelle de los Bueyes", 6 },
                    { 56, "Nueva Guinea", 6 },
                    { 57, "Paiwas", 6 },
                    { 58, "Condega", 7 },
                    { 59, "Estelí", 7 },
                    { 60, "La Trinidad", 7 },
                    { 61, "Pueblo Nuevo", 7 },
                    { 62, "San Juan de Limay", 7 },
                    { 63, "San Nicolás", 7 },
                    { 64, "Diriá", 8 },
                    { 65, "Diriomo", 8 },
                    { 66, "Granada", 8 },
                    { 67, "Nandaime", 8 },
                    { 68, "El Cuá", 9 },
                    { 69, "Jinotega", 9 },
                    { 70, "La Concordia", 9 },
                    { 71, "San José de Bocay", 9 },
                    { 72, "San Rafael del Norte", 9 },
                    { 73, "San Sebastián de Yalí", 9 },
                    { 74, "Santa María de Pantasma", 9 },
                    { 75, "Wiwilí de Jinotega", 9 },
                    { 76, "Achuapa", 10 },
                    { 77, "El Jicaral", 10 },
                    { 78, "El Sauce", 10 },
                    { 79, "La Paz Centro", 10 },
                    { 80, "Larreynaga", 10 },
                    { 81, "León", 10 },
                    { 82, "Nagarote", 10 },
                    { 83, "Quezalguaque", 10 },
                    { 84, "Santa Rosa del Peñón", 10 }
                });

            migrationBuilder.InsertData(
                table: "Town",
                columns: new[] { "Id", "Name", "StateId" },
                values: new object[,]
                {
                    { 85, "Telica", 10 },
                    { 86, "Las Sabanas", 11 },
                    { 87, "Palacagüina", 11 },
                    { 88, "San José de Cusmapa", 11 },
                    { 89, "San Juan de Río Coco", 11 },
                    { 90, "San Lucas", 11 },
                    { 91, "Somoto", 11 },
                    { 92, "Telpaneca", 11 },
                    { 93, "Totogalpa", 11 },
                    { 94, "Yalagüina", 11 },
                    { 95, "Ciudad Sandino", 12 },
                    { 96, "El Crucero", 12 },
                    { 97, "Managua", 12 },
                    { 98, "Mateare", 12 },
                    { 99, "San Francisco Libre", 12 },
                    { 100, "San Rafael del Sur", 12 },
                    { 101, "Ticuantepe", 12 },
                    { 102, "Tipitapa", 12 },
                    { 103, "Villa El Carmen", 12 },
                    { 104, "Catarina", 13 },
                    { 105, "La Concepción", 13 },
                    { 106, "Masatepe", 13 },
                    { 107, "Masaya", 13 },
                    { 108, "Nandasmo", 13 },
                    { 109, "Nindirí", 13 },
                    { 110, "Niquinohomo", 13 },
                    { 111, "San Juan de Oriente", 13 },
                    { 112, "Tisma", 13 },
                    { 113, "Ciudad Darío", 14 },
                    { 114, "El Tuma -La Dalia", 14 },
                    { 115, "Esquipulas", 14 },
                    { 116, "Matagalpa", 14 },
                    { 117, "Matiguás", 14 },
                    { 118, "Muy Muy", 14 },
                    { 119, "Rancho Grande", 14 },
                    { 120, "Río Blanco", 14 },
                    { 121, "San Dionisio", 14 },
                    { 122, "San Isidro", 14 },
                    { 123, "San Ramón", 14 },
                    { 124, "Sébaco", 14 },
                    { 125, "Terrabona", 14 },
                    { 126, "Ciudad Antigua", 15 }
                });

            migrationBuilder.InsertData(
                table: "Town",
                columns: new[] { "Id", "Name", "StateId" },
                values: new object[,]
                {
                    { 127, "Dipilto", 15 },
                    { 128, "El Jícaro", 15 },
                    { 129, "Jalapa", 15 },
                    { 130, "Macuelizo", 15 },
                    { 131, "Mozonte", 15 },
                    { 132, "Murra", 15 },
                    { 133, "Ocotal", 15 },
                    { 134, "Quilalí", 15 },
                    { 135, "San Fernando", 15 },
                    { 136, "Santa María", 15 },
                    { 137, "Wiwilí", 15 },
                    { 138, "El Almendro", 16 },
                    { 139, "El Castillo", 16 },
                    { 140, "Morrito", 16 },
                    { 141, "San Carlos", 16 },
                    { 142, "San Juan del Norte", 16 },
                    { 143, "San Miguelito", 16 },
                    { 144, "Altagracia", 17 },
                    { 145, "Belén", 17 },
                    { 146, "Buenos Aires", 17 },
                    { 147, "Cárdenas", 17 },
                    { 148, "Moyogalpa", 17 },
                    { 149, "Potosí", 17 },
                    { 150, "Rivas", 17 },
                    { 151, "San Jorge", 17 },
                    { 152, "San Juan del Sur", 17 },
                    { 153, "Tola", 17 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_CreatedByUserId",
                table: "Client",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_ModifiedByUserId",
                table: "Client",
                column: "ModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_TownId",
                table: "Client",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_Town_StateId",
                table: "Town",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Town");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "State");
        }
    }
}
