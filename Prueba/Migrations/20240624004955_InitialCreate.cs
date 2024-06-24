using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prueba.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistorialMedico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialMedico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatosContacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HistorialMedicoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paciente_HistorialMedico_HistorialMedicoId",
                        column: x => x.HistorialMedicoId,
                        principalTable: "HistorialMedico",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Alergia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    HistorialMedicoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alergia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alergia_HistorialMedico_HistorialMedicoId",
                        column: x => x.HistorialMedicoId,
                        principalTable: "HistorialMedico",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Alergia_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Condicion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    HistorialMedicoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condicion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Condicion_HistorialMedico_HistorialMedicoId",
                        column: x => x.HistorialMedicoId,
                        principalTable: "HistorialMedico",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Condicion_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    HistorialMedicoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicacion_HistorialMedico_HistorialMedicoId",
                        column: x => x.HistorialMedicoId,
                        principalTable: "HistorialMedico",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Medicacion_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tratamiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstruccionesDosificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrecuenciaAdministracion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EfectosSecundarios = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    HistorialMedicoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tratamiento_HistorialMedico_HistorialMedicoId",
                        column: x => x.HistorialMedicoId,
                        principalTable: "HistorialMedico",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tratamiento_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alergia_HistorialMedicoId",
                table: "Alergia",
                column: "HistorialMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alergia_PacienteId",
                table: "Alergia",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Condicion_HistorialMedicoId",
                table: "Condicion",
                column: "HistorialMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Condicion_PacienteId",
                table: "Condicion",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicacion_HistorialMedicoId",
                table: "Medicacion",
                column: "HistorialMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicacion_PacienteId",
                table: "Medicacion",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_HistorialMedicoId",
                table: "Paciente",
                column: "HistorialMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tratamiento_HistorialMedicoId",
                table: "Tratamiento",
                column: "HistorialMedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tratamiento_PacienteId",
                table: "Tratamiento",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alergia");

            migrationBuilder.DropTable(
                name: "Condicion");

            migrationBuilder.DropTable(
                name: "Medicacion");

            migrationBuilder.DropTable(
                name: "Tratamiento");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "HistorialMedico");
        }
    }
}
