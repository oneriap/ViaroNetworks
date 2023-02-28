using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ViaroTest.Migrations
{
    /// <inheritdoc />
    public partial class CreateAlumnoGrado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlumnoGrados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdAlumno = table.Column<int>(type: "int", nullable: false),
                    IdGrado = table.Column<int>(type: "int", nullable: false),
                    SeccionGrupo = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoGrados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlumnoGrados_Alumnos_IdAlumno",
                        column: x => x.IdAlumno,
                        principalTable: "Alumnos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumnoGrados_Grados_IdGrado",
                        column: x => x.IdGrado,
                        principalTable: "Grados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoGrados_IdAlumno",
                table: "AlumnoGrados",
                column: "IdAlumno");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoGrados_IdGrado",
                table: "AlumnoGrados",
                column: "IdGrado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlumnoGrados");
        }
    }
}
