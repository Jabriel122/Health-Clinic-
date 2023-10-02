using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.health_clinic.manha.Migrations
{
    /// <inheritdoc />
    public partial class Marchetti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoDeUsuario",
                table: "TiposDeUsuario",
                newName: "Titulo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "TiposDeUsuario",
                newName: "TipoDeUsuario");
        }
    }
}
