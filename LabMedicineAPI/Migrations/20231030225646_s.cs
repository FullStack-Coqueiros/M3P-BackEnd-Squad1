using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabMedicineAPI.Migrations
{
    /// <inheritdoc />
    public partial class s : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
