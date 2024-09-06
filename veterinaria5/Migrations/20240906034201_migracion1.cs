using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace veterinaria5.Migrations
{
    public partial class migracion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DUENO",
                columns: table => new
                {
                    ID_DUENO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TIPO_DOCUMENTO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    NUM_DOCUMENTO = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    NOMBRE = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DUENO", x => x.ID_DUENO);
                });

            migrationBuilder.CreateTable(
                name: "MASCOTA",
                columns: table => new
                {
                    ID_MASCOTA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TIPO = table.Column<string>(type: "varchar(45)", unicode: false, maxLength: 45, nullable: false),
                    NOMBRE = table.Column<string>(type: "text", unicode: false, nullable: false),
                    PESO = table.Column<int>(type: "int", unicode: false, nullable: false),
                    FECHA_NACIMIENTO = table.Column<DateTime>(type: "DateTime", unicode: false, nullable: false),
                    ID_DUENO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MASCOTA", x => x.ID_MASCOTA);
                    table.ForeignKey(
                        name: "FK_MASCOTA",
                        column: x => x.ID_DUENO,
                        principalTable: "DUENO",
                        principalColumn: "ID_DUENO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MASCOTA_ID_DUENO",
                table: "MASCOTA",
                column: "ID_DUENO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MASCOTA");

            migrationBuilder.DropTable(
                name: "DUENO");
        }
    }
}
