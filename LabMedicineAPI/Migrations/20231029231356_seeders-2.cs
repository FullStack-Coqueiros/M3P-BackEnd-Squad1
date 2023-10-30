using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LabMedicineAPI.Migrations
{
    /// <inheritdoc />
    public partial class seeders2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RgOrgaoExpedidor = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Naturalidade = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Alergias = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    CuidadosEspecificos = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Convenio = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    ContatoEmergencia = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    NumeroConvenio = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    ValidadeConvenio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomeCompleto = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Genero = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    StatusSistema = table.Column<string>(type: "VARCHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefone = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Tipo = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    NomeCompleto = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    Genero = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    StatusSistema = table.Column<string>(type: "VARCHAR(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Cidade = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Estado = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Logradouro = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Numero = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Complemento = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Bairro = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    PontoReferencia = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotivoConsulta = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    ProblemaDescricao = table.Column<string>(type: "VARCHAR(1024)", maxLength: 1024, nullable: false),
                    MedicacaoIndicada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DosagemEPrecaucoes = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusSistema = table.Column<bool>(type: "bit", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultas_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consultas_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dieta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDieta = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    DescricaoDieta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDieta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusSistema = table.Column<bool>(type: "bit", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dieta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dieta_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dieta_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeExame = table.Column<string>(type: "VARCHAR(64)", maxLength: 64, nullable: false),
                    TipoExame = table.Column<string>(type: "VARCHAR(32)", maxLength: 32, nullable: false),
                    Laboratorio = table.Column<string>(type: "VARCHAR(32)", maxLength: 32, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resultados = table.Column<string>(type: "VARCHAR(1024)", maxLength: 1024, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusSistema = table.Column<bool>(type: "bit", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exame_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exame_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exercicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeSerieExerc = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    TipoExerc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantidadeSemana = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DescricaoExerc = table.Column<string>(type: "VARCHAR(1000)", maxLength: 1000, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusSistema = table.Column<bool>(type: "bit", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercicio_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exercicio_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeMedicamento = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    TipoMedicamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacoes = table.Column<string>(type: "VARCHAR(1000)", maxLength: 1000, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusSistema = table.Column<bool>(type: "bit", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicamento_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicamento_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "CPF", "Email", "Genero", "NomeCompleto", "Senha", "StatusSistema", "Telefone", "Tipo" },
                values: new object[,]
                {
                    { 1, "09465328956", "admin1@admin.com", "Outro", "4Devs", "12345678", "1", "48998000054", "Administrador" },
                    { 2, "45662548652", "rafael@gmail.com", "Masculino", "Rafael Silva", "12345678", "1", "48995321544", "Médico" },
                    { 3, "06532589965", "alessandra@gmail.com", "Feminino", "Alessandra", "12345678", "1", "48995874233", "Enfermeiro" },
                    { 4, "06523144785", "william84@gmail.com", "Masculino", "William", "12345678", "1", "48996524233", "Enfermeiro" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PacienteId",
                table: "Consultas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_UsuarioId",
                table: "Consultas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Dieta_PacienteId",
                table: "Dieta",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Dieta_UsuarioId",
                table: "Dieta",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_PacienteId",
                table: "Endereco",
                column: "PacienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exame_PacienteId",
                table: "Exame",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Exame_UsuarioId",
                table: "Exame",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicio_PacienteId",
                table: "Exercicio",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercicio_UsuarioId",
                table: "Exercicio",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_PacienteId",
                table: "Medicamento",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_UsuarioId",
                table: "Medicamento",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Dieta");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "Exame");

            migrationBuilder.DropTable(
                name: "Exercicio");

            migrationBuilder.DropTable(
                name: "Medicamento");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
