using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.health_clinic.manha.Migrations
{
    /// <inheritdoc />
    public partial class BDHealthClinic3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Médico_IdMedico",
                table: "Consulta");

            migrationBuilder.DropTable(
                name: "Médico");

            migrationBuilder.DropTable(
                name: "Clínica");

            migrationBuilder.CreateTable(
                name: "Clinica",
                columns: table => new
                {
                    IdClinica = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeFantasia = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Endereco = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    HorarioAbertura = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    HorarioFechamento = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    CNPJ = table.Column<string>(type: "CHAR(14)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinica", x => x.IdClinica);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    IdMedico = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CRM = table.Column<string>(type: " VARCHAR(8)", nullable: false),
                    IdEspecialidade = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdClinica = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.IdMedico);
                    table.ForeignKey(
                        name: "FK_Medico_Clinica_IdClinica",
                        column: x => x.IdClinica,
                        principalTable: "Clinica",
                        principalColumn: "IdClinica",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medico_Especialidades_IdEspecialidade",
                        column: x => x.IdEspecialidade,
                        principalTable: "Especialidades",
                        principalColumn: "idEspecialidade",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medico_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medico_IdClinica",
                table: "Medico",
                column: "IdClinica");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_IdEspecialidade",
                table: "Medico",
                column: "IdEspecialidade");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_IdUsuario",
                table: "Medico",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Medico_IdMedico",
                table: "Consulta",
                column: "IdMedico",
                principalTable: "Medico",
                principalColumn: "IdMedico",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consulta_Medico_IdMedico",
                table: "Consulta");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Clinica");

            migrationBuilder.CreateTable(
                name: "Clínica",
                columns: table => new
                {
                    IdClinica = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CNPJ = table.Column<string>(type: "CHAR(14)", nullable: false),
                    Endereco = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    HorarioAbertura = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    HorarioFechamento = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    NomeFantasia = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "VARCHAR(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clínica", x => x.IdClinica);
                });

            migrationBuilder.CreateTable(
                name: "Médico",
                columns: table => new
                {
                    idMedico = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdClinica = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdEspecialidade = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CRM = table.Column<string>(type: " VARCHAR(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Médico", x => x.idMedico);
                    table.ForeignKey(
                        name: "FK_Médico_Clínica_IdClinica",
                        column: x => x.IdClinica,
                        principalTable: "Clínica",
                        principalColumn: "IdClinica",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Médico_Especialidades_IdEspecialidade",
                        column: x => x.IdEspecialidade,
                        principalTable: "Especialidades",
                        principalColumn: "idEspecialidade",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Médico_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Médico_IdClinica",
                table: "Médico",
                column: "IdClinica");

            migrationBuilder.CreateIndex(
                name: "IX_Médico_IdEspecialidade",
                table: "Médico",
                column: "IdEspecialidade");

            migrationBuilder.CreateIndex(
                name: "IX_Médico_IdUsuario",
                table: "Médico",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Consulta_Médico_IdMedico",
                table: "Consulta",
                column: "IdMedico",
                principalTable: "Médico",
                principalColumn: "idMedico",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
