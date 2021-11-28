using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Matriculas_API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AP_Vargas_Rogery_Alumnos",
                schema: "dbo",
                columns: table => new
                {
                    alumno_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    alumno_apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    alumno_nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    alumno_fechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    alumno_sexo = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AP_Vargas_Rogery_Alumnos", x => x.alumno_id);
                });

            migrationBuilder.CreateTable(
                name: "AP_Vargas_Rogery_Cursos",
                schema: "dbo",
                columns: table => new
                {
                    curso_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    curso_nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    curso_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    curso_obligatoriedad = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AP_Vargas_Rogery_Cursos", x => x.curso_id);
                });

            migrationBuilder.CreateTable(
                name: "AP_Vargas_Rogery_Inscripciones_curso",
                schema: "dbo",
                columns: table => new
                {
                    inscripcion_curso_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    alumno_id = table.Column<int>(type: "int", nullable: false),
                    curso_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AP_Vargas_Rogery_Inscripciones_curso", x => x.inscripcion_curso_id);
                    table.ForeignKey(
                        name: "FK_AP_Vargas_Rogery_Inscripciones_curso_AP_Vargas_Rogery_Alumnos_alumno_id",
                        column: x => x.alumno_id,
                        principalSchema: "dbo",
                        principalTable: "AP_Vargas_Rogery_Alumnos",
                        principalColumn: "alumno_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AP_Vargas_Rogery_Inscripciones_curso_AP_Vargas_Rogery_Cursos_curso_id",
                        column: x => x.curso_id,
                        principalSchema: "dbo",
                        principalTable: "AP_Vargas_Rogery_Cursos",
                        principalColumn: "curso_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AP_Vargas_Rogery_Notas",
                schema: "dbo",
                columns: table => new
                {
                    nota_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nota_practica_1 = table.Column<float>(type: "real", nullable: true),
                    nota_practica_2 = table.Column<float>(type: "real", nullable: true),
                    nota_practica_3 = table.Column<float>(type: "real", nullable: true),
                    nota_parcial = table.Column<float>(type: "real", nullable: true),
                    nota_final = table.Column<float>(type: "real", nullable: true),
                    inscripcion_curso_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AP_Vargas_Rogery_Notas", x => x.nota_id);
                    table.ForeignKey(
                        name: "FK_AP_Vargas_Rogery_Notas_AP_Vargas_Rogery_Inscripciones_curso_inscripcion_curso_id",
                        column: x => x.inscripcion_curso_id,
                        principalSchema: "dbo",
                        principalTable: "AP_Vargas_Rogery_Inscripciones_curso",
                        principalColumn: "inscripcion_curso_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AP_Vargas_Rogery_Inscripciones_curso_alumno_id",
                schema: "dbo",
                table: "AP_Vargas_Rogery_Inscripciones_curso",
                column: "alumno_id");

            migrationBuilder.CreateIndex(
                name: "IX_AP_Vargas_Rogery_Inscripciones_curso_curso_id",
                schema: "dbo",
                table: "AP_Vargas_Rogery_Inscripciones_curso",
                column: "curso_id");

            migrationBuilder.CreateIndex(
                name: "IX_AP_Vargas_Rogery_Notas_inscripcion_curso_id",
                schema: "dbo",
                table: "AP_Vargas_Rogery_Notas",
                column: "inscripcion_curso_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AP_Vargas_Rogery_Notas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AP_Vargas_Rogery_Inscripciones_curso",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AP_Vargas_Rogery_Alumnos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AP_Vargas_Rogery_Cursos",
                schema: "dbo");
        }
    }
}
