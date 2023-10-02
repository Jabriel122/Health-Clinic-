using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.health_clinic.manha.Migrations
{
    /// <inheritdoc />
    public partial class BD2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clínica",
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
                    table.PrimaryKey("PK_Clínica", x => x.IdClinica);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    idEspecialidade = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeEspecialidade = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.idEspecialidade);
                });

            migrationBuilder.CreateTable(
                name: "TiposDeUsuario",
                columns: table => new
                {
                    IdTipoDeUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TipoDeUsuario = table.Column<string>(type: "VARCHAR(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDeUsuario", x => x.IdTipoDeUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Senha = table.Column<string>(type: "CHAR(60)", nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(150)", nullable: false),
                    IdTipoDeUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_TiposDeUsuario_IdTipoDeUsuario",
                        column: x => x.IdTipoDeUsuario,
                        principalTable: "TiposDeUsuario",
                        principalColumn: "IdTipoDeUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Médico",
                columns: table => new
                {
                    idMedico = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CRM = table.Column<string>(type: " VARCHAR(8)", nullable: false),
                    IdEspecialidade = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdClinica = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    IdPacioente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataDeNascimento = table.Column<DateTime>(type: "DATE", nullable: false),
                    Genero = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.IdPacioente);
                    table.ForeignKey(
                        name: "FK_Paciente_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    IdConsulta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataConsultaEHorarioConsulta = table.Column<DateTime>(type: "SMALLDATETIME", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    IdMedico = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPaciente = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.IdConsulta);
                    table.ForeignKey(
                        name: "FK_Consulta_Médico_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Médico",
                        principalColumn: "idMedico",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Paciente_IdPaciente",
                        column: x => x.IdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "IdPacioente",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ComentarioConsulta",
                columns: table => new
                {
                    IdComentarioConsulta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comentario = table.Column<string>(type: "TEXT", nullable: false),
                    situacao = table.Column<bool>(type: "bit", nullable: false),
                    IdConsulta = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentarioConsulta", x => x.IdComentarioConsulta);
                    table.ForeignKey(
                        name: "FK_ComentarioConsulta_Consulta_IdConsulta",
                        column: x => x.IdConsulta,
                        principalTable: "Consulta",
                        principalColumn: "IdConsulta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioConsulta_IdConsulta",
                table: "ComentarioConsulta",
                column: "IdConsulta");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdMedico",
                table: "Consulta",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_IdPaciente",
                table: "Consulta",
                column: "IdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Especialidades_NomeEspecialidade",
                table: "Especialidades",
                column: "NomeEspecialidade");

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

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_CPF",
                table: "Paciente",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_IdUsuario",
                table: "Paciente",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_TiposDeUsuario_IdTipoDeUsuario",
                table: "TiposDeUsuario",
                column: "IdTipoDeUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdTipoDeUsuario",
                table: "Usuario",
                column: "IdTipoDeUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentarioConsulta");

            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Médico");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Clínica");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "TiposDeUsuario");
        }
    }
}
