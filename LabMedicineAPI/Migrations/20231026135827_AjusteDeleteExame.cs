using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabMedicineAPI.Migrations
{
    /// <inheritdoc />
    public partial class AjusteDeleteExame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exame_Paciente_PacienteId",
                table: "Exame");

            migrationBuilder.AlterColumn<string>(
                name: "StatusSistema",
                table: "Usuario",
                type: "VARCHAR(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR");

            migrationBuilder.AlterColumn<string>(
                name: "StatusSistema",
                table: "Paciente",
                type: "VARCHAR(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR");

            migrationBuilder.AddForeignKey(
                name: "FK_Exame_Paciente_PacienteId",
                table: "Exame",
                column: "PacienteId",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exame_Paciente_PacienteId",
                table: "Exame");

            migrationBuilder.AlterColumn<string>(
                name: "StatusSistema",
                table: "Usuario",
                type: "VARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(1)");

            migrationBuilder.AlterColumn<string>(
                name: "StatusSistema",
                table: "Paciente",
                type: "VARCHAR",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(1)");

            migrationBuilder.AddForeignKey(
                name: "FK_Exame_Paciente_PacienteId",
                table: "Exame",
                column: "PacienteId",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
