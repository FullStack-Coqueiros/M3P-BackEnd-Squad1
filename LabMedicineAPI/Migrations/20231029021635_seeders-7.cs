using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LabMedicineAPI.Migrations
{
    /// <inheritdoc />
    public partial class seeders7 : Migration
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
                table: "Paciente",
                columns: new[] { "Id", "Alergias", "CPF", "ContatoEmergencia", "Convenio", "CuidadosEspecificos", "DataNascimento", "Email", "EstadoCivil", "Genero", "Naturalidade", "NomeCompleto", "NumeroConvenio", "RgOrgaoExpedidor", "StatusSistema", "Telefone", "ValidadeConvenio" },
                values: new object[,]
                {
                    { 1, "Nenhuma alergia conhecida", "09856326588", "48996325484", "Plano de Saúde ABC", "Nenhum cuidado específico", new DateTime(1980, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "amandasq95@gmail.com", "Casado", "Feminino", "São Paulo, SP", "Amanda Siqueira", "98765432", "1234567", "1", "(11) 555-1234", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Nenhuma alergia conhecida", "09856326588", "48996325484", "Plano de Saúde ABC", "Nenhum cuidado específico", new DateTime(1982, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "paciente2@example.com", "Casado", "Feminino", "São Paulo, SP", "Paciente 2", "98765432", "1234567", "1", "(11) 555-1234", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Nenhuma alergia conhecida", "09856326588", "48996325484", "Plano de Saúde ABC", "Nenhum cuidado específico", new DateTime(1984, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "paciente4@example.com", "Casado", "Feminino", "São Paulo, SP", "Paciente 4", "98765432", "1234567", "1", "(11) 555-1234", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Nenhuma alergia conhecida", "09856326588", "48996325484", "Plano de Saúde ABC", "Nenhum cuidado específico", new DateTime(1986, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "paciente6@example.com", "Casado", "Feminino", "São Paulo, SP", "Paciente 6", "98765432", "1234567", "1", "(11) 555-1234", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Nenhuma alergia conhecida", "09856326588", "48996325484", "Plano de Saúde ABC", "Nenhum cuidado específico", new DateTime(1988, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "paciente8@example.com", "Casado", "Feminino", "São Paulo, SP", "Paciente 8", "98765432", "1234567", "1", "(11) 555-1234", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Nenhuma alergia conhecida", "09856326588", "48996325484", "Plano de Saúde ABC", "Nenhum cuidado específico", new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "paciente10@example.com", "Casado", "Feminino", "São Paulo, SP", "Paciente 10", "98765432", "1234567", "1", "(11) 555-1234", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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

            migrationBuilder.InsertData(
                table: "Consultas",
                columns: new[] { "Id", "Data", "DosagemEPrecaucoes", "Horario", "MedicacaoIndicada", "MotivoConsulta", "PacienteId", "ProblemaDescricao", "StatusSistema", "UsuarioId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 27, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7010), "Dosagem e Precauções", new DateTime(2023, 10, 28, 22, 16, 34, 662, DateTimeKind.Local).AddTicks(7023), "Medicação Indicada", "Motivo da Consulta 1", 1, "Descrição do problema para Consulta 1", true, 2 },
                    { 2, new DateTime(2023, 10, 26, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7051), "Dosagem e Precauções", new DateTime(2023, 10, 28, 21, 16, 34, 662, DateTimeKind.Local).AddTicks(7052), "Medicação Indicada", "Motivo da Consulta 2", 1, "Descrição do problema para Consulta 2", true, 2 },
                    { 3, new DateTime(2023, 10, 25, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7069), "Dosagem e Precauções", new DateTime(2023, 10, 28, 20, 16, 34, 662, DateTimeKind.Local).AddTicks(7071), "Medicação Indicada", "Motivo da Consulta 3", 1, "Descrição do problema para Consulta 3", true, 2 },
                    { 4, new DateTime(2023, 10, 24, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7163), "Dosagem e Precauções", new DateTime(2023, 10, 28, 19, 16, 34, 662, DateTimeKind.Local).AddTicks(7164), "Medicação Indicada", "Motivo da Consulta 4", 1, "Descrição do problema para Consulta 4", true, 2 },
                    { 5, new DateTime(2023, 10, 23, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7180), "Dosagem e Precauções", new DateTime(2023, 10, 28, 18, 16, 34, 662, DateTimeKind.Local).AddTicks(7181), "Medicação Indicada", "Motivo da Consulta 5", 1, "Descrição do problema para Consulta 5", true, 2 },
                    { 6, new DateTime(2023, 10, 22, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7198), "Dosagem e Precauções", new DateTime(2023, 10, 28, 17, 16, 34, 662, DateTimeKind.Local).AddTicks(7199), "Medicação Indicada", "Motivo da Consulta 6", 1, "Descrição do problema para Consulta 6", true, 2 },
                    { 7, new DateTime(2023, 10, 21, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7213), "Dosagem e Precauções", new DateTime(2023, 10, 28, 16, 16, 34, 662, DateTimeKind.Local).AddTicks(7214), "Medicação Indicada", "Motivo da Consulta 7", 1, "Descrição do problema para Consulta 7", true, 2 },
                    { 8, new DateTime(2023, 10, 20, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7229), "Dosagem e Precauções", new DateTime(2023, 10, 28, 15, 16, 34, 662, DateTimeKind.Local).AddTicks(7229), "Medicação Indicada", "Motivo da Consulta 8", 1, "Descrição do problema para Consulta 8", true, 2 },
                    { 9, new DateTime(2023, 10, 19, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7244), "Dosagem e Precauções", new DateTime(2023, 10, 28, 14, 16, 34, 662, DateTimeKind.Local).AddTicks(7245), "Medicação Indicada", "Motivo da Consulta 9", 1, "Descrição do problema para Consulta 9", true, 2 },
                    { 10, new DateTime(2023, 10, 18, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7263), "Dosagem e Precauções", new DateTime(2023, 10, 28, 13, 16, 34, 662, DateTimeKind.Local).AddTicks(7264), "Medicação Indicada", "Motivo da Consulta 10", 1, "Descrição do problema para Consulta 10", true, 2 },
                    { 11, new DateTime(2023, 10, 17, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7279), "Dosagem e Precauções", new DateTime(2023, 10, 28, 12, 16, 34, 662, DateTimeKind.Local).AddTicks(7280), "Medicação Indicada", "Motivo da Consulta 11", 1, "Descrição do problema para Consulta 11", true, 2 },
                    { 12, new DateTime(2023, 10, 16, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7295), "Dosagem e Precauções", new DateTime(2023, 10, 28, 11, 16, 34, 662, DateTimeKind.Local).AddTicks(7296), "Medicação Indicada", "Motivo da Consulta 12", 1, "Descrição do problema para Consulta 12", true, 2 },
                    { 13, new DateTime(2023, 10, 15, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7310), "Dosagem e Precauções", new DateTime(2023, 10, 28, 10, 16, 34, 662, DateTimeKind.Local).AddTicks(7311), "Medicação Indicada", "Motivo da Consulta 13", 1, "Descrição do problema para Consulta 13", true, 2 },
                    { 14, new DateTime(2023, 10, 14, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7326), "Dosagem e Precauções", new DateTime(2023, 10, 28, 9, 16, 34, 662, DateTimeKind.Local).AddTicks(7327), "Medicação Indicada", "Motivo da Consulta 14", 1, "Descrição do problema para Consulta 14", true, 2 },
                    { 15, new DateTime(2023, 10, 13, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7342), "Dosagem e Precauções", new DateTime(2023, 10, 28, 8, 16, 34, 662, DateTimeKind.Local).AddTicks(7343), "Medicação Indicada", "Motivo da Consulta 15", 1, "Descrição do problema para Consulta 15", true, 2 }
                });

            migrationBuilder.InsertData(
                table: "Dieta",
                columns: new[] { "Id", "Data", "DescricaoDieta", "Horario", "NomeDieta", "PacienteId", "StatusSistema", "TipoDieta", "UsuarioId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 27, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7963), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 28, 22, 16, 34, 662, DateTimeKind.Local).AddTicks(7964), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 2, new DateTime(2023, 10, 26, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7986), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 28, 21, 16, 34, 662, DateTimeKind.Local).AddTicks(7986), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 3, new DateTime(2023, 10, 25, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7999), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 28, 20, 16, 34, 662, DateTimeKind.Local).AddTicks(8000), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 4, new DateTime(2023, 10, 24, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8012), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 28, 19, 16, 34, 662, DateTimeKind.Local).AddTicks(8013), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 5, new DateTime(2023, 10, 23, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8025), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 28, 18, 16, 34, 662, DateTimeKind.Local).AddTicks(8026), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 6, new DateTime(2023, 10, 22, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8039), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 28, 17, 16, 34, 662, DateTimeKind.Local).AddTicks(8040), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 7, new DateTime(2023, 10, 21, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8052), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 28, 16, 16, 34, 662, DateTimeKind.Local).AddTicks(8053), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 8, new DateTime(2023, 10, 20, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8065), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 28, 15, 16, 34, 662, DateTimeKind.Local).AddTicks(8066), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 9, new DateTime(2023, 10, 19, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8077), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 28, 14, 16, 34, 662, DateTimeKind.Local).AddTicks(8078), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 10, new DateTime(2023, 10, 18, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8092), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 28, 13, 16, 34, 662, DateTimeKind.Local).AddTicks(8093), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 11, new DateTime(2023, 10, 17, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8104), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 28, 12, 16, 34, 662, DateTimeKind.Local).AddTicks(8105), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 12, new DateTime(2023, 10, 16, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8117), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 28, 11, 16, 34, 662, DateTimeKind.Local).AddTicks(8118), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 13, new DateTime(2023, 10, 15, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8130), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 28, 10, 16, 34, 662, DateTimeKind.Local).AddTicks(8131), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 14, new DateTime(2023, 10, 14, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8143), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 28, 9, 16, 34, 662, DateTimeKind.Local).AddTicks(8144), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 15, new DateTime(2023, 10, 13, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8155), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 28, 8, 16, 34, 662, DateTimeKind.Local).AddTicks(8156), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 16, new DateTime(2023, 10, 12, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8168), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 28, 7, 16, 34, 662, DateTimeKind.Local).AddTicks(8169), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 17, new DateTime(2023, 10, 11, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8181), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 28, 6, 16, 34, 662, DateTimeKind.Local).AddTicks(8182), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 18, new DateTime(2023, 10, 10, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8245), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 28, 5, 16, 34, 662, DateTimeKind.Local).AddTicks(8246), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 19, new DateTime(2023, 10, 9, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8257), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 28, 4, 16, 34, 662, DateTimeKind.Local).AddTicks(8258), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 20, new DateTime(2023, 10, 8, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8271), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 28, 3, 16, 34, 662, DateTimeKind.Local).AddTicks(8272), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 21, new DateTime(2023, 10, 7, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8284), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 28, 2, 16, 34, 662, DateTimeKind.Local).AddTicks(8285), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 22, new DateTime(2023, 10, 6, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8297), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 28, 1, 16, 34, 662, DateTimeKind.Local).AddTicks(8298), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 23, new DateTime(2023, 10, 5, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8310), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 28, 0, 16, 34, 662, DateTimeKind.Local).AddTicks(8311), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 24, new DateTime(2023, 10, 4, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8322), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 27, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8323), "Dieta Low Carb", 5, true, "lowCarb", 3 },
                    { 25, new DateTime(2023, 10, 3, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8335), "Dieta com baixa ingestão de carboidratos", new DateTime(2023, 10, 27, 22, 16, 34, 662, DateTimeKind.Local).AddTicks(8336), "Dieta Low Carb", 5, true, "lowCarb", 3 }
                });

            migrationBuilder.InsertData(
                table: "Exame",
                columns: new[] { "Id", "Data", "Horario", "Laboratorio", "NomeExame", "PacienteId", "Resultados", "StatusSistema", "TipoExame", "Url", "UsuarioId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 27, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7366), new DateTime(2023, 10, 28, 22, 16, 34, 662, DateTimeKind.Local).AddTicks(7368), "Laboratório XYZ", "Exame 1", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-1", 2 },
                    { 2, new DateTime(2023, 10, 26, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7394), new DateTime(2023, 10, 28, 21, 16, 34, 662, DateTimeKind.Local).AddTicks(7395), "Laboratório XYZ", "Exame 2", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-2", 2 },
                    { 3, new DateTime(2023, 10, 25, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7410), new DateTime(2023, 10, 28, 20, 16, 34, 662, DateTimeKind.Local).AddTicks(7411), "Laboratório XYZ", "Exame 3", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-3", 2 },
                    { 4, new DateTime(2023, 10, 24, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7425), new DateTime(2023, 10, 28, 19, 16, 34, 662, DateTimeKind.Local).AddTicks(7426), "Laboratório XYZ", "Exame 4", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-4", 2 },
                    { 5, new DateTime(2023, 10, 23, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7575), new DateTime(2023, 10, 28, 18, 16, 34, 662, DateTimeKind.Local).AddTicks(7578), "Laboratório XYZ", "Exame 5", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-5", 2 },
                    { 6, new DateTime(2023, 10, 22, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7596), new DateTime(2023, 10, 28, 17, 16, 34, 662, DateTimeKind.Local).AddTicks(7597), "Laboratório XYZ", "Exame 6", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-6", 2 },
                    { 7, new DateTime(2023, 10, 21, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7612), new DateTime(2023, 10, 28, 16, 16, 34, 662, DateTimeKind.Local).AddTicks(7613), "Laboratório XYZ", "Exame 7", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-7", 2 },
                    { 8, new DateTime(2023, 10, 20, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7627), new DateTime(2023, 10, 28, 15, 16, 34, 662, DateTimeKind.Local).AddTicks(7628), "Laboratório XYZ", "Exame 8", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-8", 2 },
                    { 9, new DateTime(2023, 10, 19, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7643), new DateTime(2023, 10, 28, 14, 16, 34, 662, DateTimeKind.Local).AddTicks(7643), "Laboratório XYZ", "Exame 9", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-9", 2 },
                    { 10, new DateTime(2023, 10, 18, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7659), new DateTime(2023, 10, 28, 13, 16, 34, 662, DateTimeKind.Local).AddTicks(7660), "Laboratório XYZ", "Exame 10", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-10", 2 },
                    { 11, new DateTime(2023, 10, 17, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7676), new DateTime(2023, 10, 28, 12, 16, 34, 662, DateTimeKind.Local).AddTicks(7677), "Laboratório XYZ", "Exame 11", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-11", 2 },
                    { 12, new DateTime(2023, 10, 16, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7691), new DateTime(2023, 10, 28, 11, 16, 34, 662, DateTimeKind.Local).AddTicks(7692), "Laboratório XYZ", "Exame 12", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-12", 2 },
                    { 13, new DateTime(2023, 10, 15, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7706), new DateTime(2023, 10, 28, 10, 16, 34, 662, DateTimeKind.Local).AddTicks(7707), "Laboratório XYZ", "Exame 13", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-13", 2 },
                    { 14, new DateTime(2023, 10, 14, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7722), new DateTime(2023, 10, 28, 9, 16, 34, 662, DateTimeKind.Local).AddTicks(7722), "Laboratório XYZ", "Exame 14", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-14", 2 },
                    { 15, new DateTime(2023, 10, 13, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7737), new DateTime(2023, 10, 28, 8, 16, 34, 662, DateTimeKind.Local).AddTicks(7738), "Laboratório XYZ", "Exame 15", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-15", 2 },
                    { 16, new DateTime(2023, 10, 12, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7752), new DateTime(2023, 10, 28, 7, 16, 34, 662, DateTimeKind.Local).AddTicks(7753), "Laboratório XYZ", "Exame 16", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-16", 2 },
                    { 17, new DateTime(2023, 10, 11, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7767), new DateTime(2023, 10, 28, 6, 16, 34, 662, DateTimeKind.Local).AddTicks(7768), "Laboratório XYZ", "Exame 17", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-17", 2 },
                    { 18, new DateTime(2023, 10, 10, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7784), new DateTime(2023, 10, 28, 5, 16, 34, 662, DateTimeKind.Local).AddTicks(7785), "Laboratório XYZ", "Exame 18", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-18", 2 },
                    { 19, new DateTime(2023, 10, 9, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7801), new DateTime(2023, 10, 28, 4, 16, 34, 662, DateTimeKind.Local).AddTicks(7802), "Laboratório XYZ", "Exame 19", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-19", 2 },
                    { 20, new DateTime(2023, 10, 8, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7817), new DateTime(2023, 10, 28, 3, 16, 34, 662, DateTimeKind.Local).AddTicks(7817), "Laboratório XYZ", "Exame 20", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-20", 2 },
                    { 21, new DateTime(2023, 10, 7, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7879), new DateTime(2023, 10, 28, 2, 16, 34, 662, DateTimeKind.Local).AddTicks(7880), "Laboratório XYZ", "Exame 21", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-21", 2 },
                    { 22, new DateTime(2023, 10, 6, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7895), new DateTime(2023, 10, 28, 1, 16, 34, 662, DateTimeKind.Local).AddTicks(7896), "Laboratório XYZ", "Exame 22", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-22", 2 },
                    { 23, new DateTime(2023, 10, 5, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7910), new DateTime(2023, 10, 28, 0, 16, 34, 662, DateTimeKind.Local).AddTicks(7911), "Laboratório XYZ", "Exame 23", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-23", 2 },
                    { 24, new DateTime(2023, 10, 4, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7925), new DateTime(2023, 10, 27, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7926), "Laboratório XYZ", "Exame 24", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-24", 2 },
                    { 25, new DateTime(2023, 10, 3, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(7941), new DateTime(2023, 10, 27, 22, 16, 34, 662, DateTimeKind.Local).AddTicks(7942), "Laboratório XYZ", "Exame 25", 1, "Resultados do exame", true, "Tipo de Exame", "http://www.laboratorioxyz.com/exames/exame-25", 2 }
                });

            migrationBuilder.InsertData(
                table: "Exercicio",
                columns: new[] { "Id", "Data", "DescricaoExerc", "Horario", "NomeSerieExerc", "PacienteId", "QuantidadeSemana", "StatusSistema", "TipoExerc", "UsuarioId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 27, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8357), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 28, 22, 16, 34, 662, DateTimeKind.Local).AddTicks(8358), "Exercícios de Resistência Aeróbica", 8, 1m, true, "Resistência_aerobica", 4 },
                    { 2, new DateTime(2023, 10, 26, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8382), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 28, 21, 16, 34, 662, DateTimeKind.Local).AddTicks(8382), "Exercícios de Resistência Aeróbica", 8, 2m, true, "Resistência_aerobica", 4 },
                    { 3, new DateTime(2023, 10, 25, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8395), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 28, 20, 16, 34, 662, DateTimeKind.Local).AddTicks(8396), "Exercícios de Resistência Aeróbica", 8, 3m, true, "Resistência_aerobica", 4 },
                    { 4, new DateTime(2023, 10, 24, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8409), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 28, 19, 16, 34, 662, DateTimeKind.Local).AddTicks(8409), "Exercícios de Resistência Aeróbica", 8, 4m, true, "Resistência_aerobica", 4 },
                    { 5, new DateTime(2023, 10, 23, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8421), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 28, 18, 16, 34, 662, DateTimeKind.Local).AddTicks(8422), "Exercícios de Resistência Aeróbica", 8, 5m, true, "Resistência_aerobica", 4 },
                    { 6, new DateTime(2023, 10, 22, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8437), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 28, 17, 16, 34, 662, DateTimeKind.Local).AddTicks(8437), "Exercícios de Resistência Aeróbica", 8, 6m, true, "Resistência_aerobica", 4 },
                    { 7, new DateTime(2023, 10, 21, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8449), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 28, 16, 16, 34, 662, DateTimeKind.Local).AddTicks(8450), "Exercícios de Resistência Aeróbica", 8, 7m, true, "Resistência_aerobica", 4 },
                    { 8, new DateTime(2023, 10, 20, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8462), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 28, 15, 16, 34, 662, DateTimeKind.Local).AddTicks(8463), "Exercícios de Resistência Aeróbica", 8, 8m, true, "Resistência_aerobica", 4 },
                    { 9, new DateTime(2023, 10, 19, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8475), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 28, 14, 16, 34, 662, DateTimeKind.Local).AddTicks(8476), "Exercícios de Resistência Aeróbica", 8, 9m, true, "Resistência_aerobica", 4 },
                    { 10, new DateTime(2023, 10, 18, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8489), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 28, 13, 16, 34, 662, DateTimeKind.Local).AddTicks(8490), "Exercícios de Resistência Aeróbica", 8, 10m, true, "Resistência_aerobica", 4 },
                    { 11, new DateTime(2023, 10, 17, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8502), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 28, 12, 16, 34, 662, DateTimeKind.Local).AddTicks(8503), "Exercícios de Resistência Aeróbica", 8, 11m, true, "Resistência_aerobica", 4 },
                    { 12, new DateTime(2023, 10, 16, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8514), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 28, 11, 16, 34, 662, DateTimeKind.Local).AddTicks(8515), "Exercícios de Resistência Aeróbica", 8, 12m, true, "Resistência_aerobica", 4 },
                    { 13, new DateTime(2023, 10, 15, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8527), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 28, 10, 16, 34, 662, DateTimeKind.Local).AddTicks(8528), "Exercícios de Resistência Aeróbica", 8, 13m, true, "Resistência_aerobica", 4 },
                    { 14, new DateTime(2023, 10, 14, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8540), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 28, 9, 16, 34, 662, DateTimeKind.Local).AddTicks(8541), "Exercícios de Resistência Aeróbica", 8, 14m, true, "Resistência_aerobica", 4 },
                    { 15, new DateTime(2023, 10, 13, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8553), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 28, 8, 16, 34, 662, DateTimeKind.Local).AddTicks(8554), "Exercícios de Resistência Aeróbica", 8, 15m, true, "Resistência_aerobica", 4 },
                    { 16, new DateTime(2023, 10, 12, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8631), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 28, 7, 16, 34, 662, DateTimeKind.Local).AddTicks(8632), "Exercícios de Resistência Aeróbica", 8, 16m, true, "Resistência_aerobica", 4 },
                    { 17, new DateTime(2023, 10, 11, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8648), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 28, 6, 16, 34, 662, DateTimeKind.Local).AddTicks(8649), "Exercícios de Resistência Aeróbica", 8, 17m, true, "Resistência_aerobica", 4 },
                    { 18, new DateTime(2023, 10, 10, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8663), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 28, 5, 16, 34, 662, DateTimeKind.Local).AddTicks(8663), "Exercícios de Resistência Aeróbica", 8, 18m, true, "Resistência_aerobica", 4 },
                    { 19, new DateTime(2023, 10, 9, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8675), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 28, 4, 16, 34, 662, DateTimeKind.Local).AddTicks(8676), "Exercícios de Resistência Aeróbica", 8, 19m, true, "Resistência_aerobica", 4 },
                    { 20, new DateTime(2023, 10, 8, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8689), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 28, 3, 16, 34, 662, DateTimeKind.Local).AddTicks(8690), "Exercícios de Resistência Aeróbica", 8, 20m, true, "Resistência_aerobica", 4 },
                    { 21, new DateTime(2023, 10, 7, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8701), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 28, 2, 16, 34, 662, DateTimeKind.Local).AddTicks(8702), "Exercícios de Resistência Aeróbica", 8, 21m, true, "Resistência_aerobica", 4 },
                    { 22, new DateTime(2023, 10, 6, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8714), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 28, 1, 16, 34, 662, DateTimeKind.Local).AddTicks(8715), "Exercícios de Resistência Aeróbica", 8, 22m, true, "Resistência_aerobica", 4 },
                    { 23, new DateTime(2023, 10, 5, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8727), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 28, 0, 16, 34, 662, DateTimeKind.Local).AddTicks(8728), "Exercícios de Resistência Aeróbica", 8, 23m, true, "Resistência_aerobica", 4 },
                    { 24, new DateTime(2023, 10, 4, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8740), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 27, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8741), "Exercícios de Resistência Aeróbica", 8, 24m, true, "Resistência_aerobica", 4 },
                    { 25, new DateTime(2023, 10, 3, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8752), "Série de exercícios aeróbicos para melhorar resistência", new DateTime(2023, 10, 27, 22, 16, 34, 662, DateTimeKind.Local).AddTicks(8753), "Exercícios de Resistência Aeróbica", 8, 25m, true, "Resistência_aerobica", 4 }
                });

            migrationBuilder.InsertData(
                table: "Medicamento",
                columns: new[] { "Id", "Data", "Horario", "NomeMedicamento", "Observacoes", "PacienteId", "Quantidade", "StatusSistema", "TipoMedicamento", "Unidade", "UsuarioId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 29, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8770), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 1", 15, 10m, true, "cápsula", "mg", 2 },
                    { 2, new DateTime(2023, 10, 30, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8799), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 2", 15, 10m, true, "cápsula", "mg", 2 },
                    { 3, new DateTime(2023, 10, 31, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8814), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 3", 15, 10m, true, "cápsula", "mg", 2 },
                    { 4, new DateTime(2023, 11, 1, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8830), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 4", 15, 10m, true, "cápsula", "mg", 2 },
                    { 5, new DateTime(2023, 11, 2, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8843), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 5", 15, 10m, true, "cápsula", "mg", 2 },
                    { 6, new DateTime(2023, 11, 3, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8859), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 6", 15, 10m, true, "cápsula", "mg", 2 },
                    { 7, new DateTime(2023, 11, 4, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8874), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 7", 15, 10m, true, "cápsula", "mg", 2 },
                    { 8, new DateTime(2023, 11, 5, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8888), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 8", 15, 10m, true, "cápsula", "mg", 2 },
                    { 9, new DateTime(2023, 11, 6, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8902), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 9", 15, 10m, true, "cápsula", "mg", 2 },
                    { 10, new DateTime(2023, 11, 7, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8918), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 10", 15, 10m, true, "cápsula", "mg", 2 },
                    { 11, new DateTime(2023, 11, 8, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8933), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 11", 15, 10m, true, "cápsula", "mg", 2 },
                    { 12, new DateTime(2023, 11, 9, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(8993), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 12", 15, 10m, true, "cápsula", "mg", 2 },
                    { 13, new DateTime(2023, 11, 10, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(9008), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 13", 15, 10m, true, "cápsula", "mg", 2 },
                    { 14, new DateTime(2023, 11, 11, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(9021), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 14", 15, 10m, true, "cápsula", "mg", 2 },
                    { 15, new DateTime(2023, 11, 12, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(9035), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 15", 15, 10m, true, "cápsula", "mg", 2 },
                    { 16, new DateTime(2023, 11, 13, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(9048), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 16", 15, 10m, true, "cápsula", "mg", 2 },
                    { 17, new DateTime(2023, 11, 14, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(9062), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 17", 15, 10m, true, "cápsula", "mg", 2 },
                    { 18, new DateTime(2023, 11, 15, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(9078), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 18", 15, 10m, true, "cápsula", "mg", 2 },
                    { 19, new DateTime(2023, 11, 16, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(9091), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 19", 15, 10m, true, "cápsula", "mg", 2 },
                    { 20, new DateTime(2023, 11, 17, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(9105), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 20", 15, 10m, true, "cápsula", "mg", 2 },
                    { 21, new DateTime(2023, 11, 18, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(9118), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 21", 15, 10m, true, "cápsula", "mg", 2 },
                    { 22, new DateTime(2023, 11, 19, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(9132), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 22", 15, 10m, true, "cápsula", "mg", 2 },
                    { 23, new DateTime(2023, 11, 20, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(9145), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 23", 15, 10m, true, "cápsula", "mg", 2 },
                    { 24, new DateTime(2023, 11, 21, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(9159), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 24", 15, 10m, true, "cápsula", "mg", 2 },
                    { 25, new DateTime(2023, 11, 22, 23, 16, 34, 662, DateTimeKind.Local).AddTicks(9173), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medicamento 1", "Observações do medicamento 25", 15, 10m, true, "cápsula", "mg", 2 }
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
