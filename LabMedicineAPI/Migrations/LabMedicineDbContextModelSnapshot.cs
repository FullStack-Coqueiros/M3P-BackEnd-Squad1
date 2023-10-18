﻿// <auto-generated />
using System;
using LabMedicineAPI.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LabMedicineAPI.Migrations
{
    [DbContext(typeof(LabMedicineDbContext))]
    partial class LabMedicineDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LabMedicineAPI.Model.ConsultaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("DosagemEPrecaucoes")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("VARCHAR");

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime2");

                    b.Property<string>("MedicacaoIndicada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotivoConsulta")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<string>("ProblemaDescricao")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("VARCHAR");

                    b.Property<bool>("StatusSistema")
                        .HasColumnType("bit");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("LabMedicineAPI.Model.DietaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescricaoDieta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeDieta")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<bool>("StatusSistema")
                        .HasColumnType("bit");

                    b.Property<int>("TipoDieta")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Dieta");
                });

            modelBuilder.Entity("LabMedicineAPI.Model.EnderecoModel", b =>
                {
                    b.Property<int>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnderecoId"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<string>("PontoReferencia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("EnderecoId");

                    b.HasIndex("PacienteId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("LabMedicineAPI.Model.ExameModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime2");

                    b.Property<string>("Laboratorio")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("NomeExame")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<string>("Resultados")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("VARCHAR");

                    b.Property<bool>("StatusSistema")
                        .HasColumnType("bit");

                    b.Property<string>("TipoExame")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Exame");
                });

            modelBuilder.Entity("LabMedicineAPI.Model.ExercicioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescricaoExerc")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("VARCHAR");

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeSerieExerc")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<decimal>("QuantidadeSemana")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("StatusSistema")
                        .HasColumnType("bit");

                    b.Property<int>("TipoExerc")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Exercicio");
                });

            modelBuilder.Entity("LabMedicineAPI.Model.MedicamentoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeMedicamento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantidade")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("StatusSistema")
                        .HasColumnType("bit");

                    b.Property<int>("TipoMedicamento")
                        .HasColumnType("int");

                    b.Property<int>("Unidade")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Medicamento");
                });

            modelBuilder.Entity("LabMedicineAPI.Model.PacienteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alergias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Convenio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CuidadosEspecificos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("EstadoCivil")
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("NumeroConvenio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RgOrgaoExpedidor")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("StatusSistema")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ValidadeConvenio")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("LabMedicineAPI.Model.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("StatusSistema")
                        .IsRequired()
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("LabMedicineAPI.Model.ConsultaModel", b =>
                {
                    b.HasOne("LabMedicineAPI.Model.PacienteModel", "Paciente")
                        .WithMany("Consultas")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LabMedicineAPI.Model.UsuarioModel", "Usuario")
                        .WithMany("Consultas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("LabMedicineAPI.Model.DietaModel", b =>
                {
                    b.HasOne("LabMedicineAPI.Model.PacienteModel", "Paciente")
                        .WithMany("Dietas")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LabMedicineAPI.Model.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("LabMedicineAPI.Model.EnderecoModel", b =>
                {
                    b.HasOne("LabMedicineAPI.Model.PacienteModel", "Paciente")
                        .WithMany("Enderecos")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LabMedicineAPI.Model.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("LabMedicineAPI.Model.ExameModel", b =>
                {
                    b.HasOne("LabMedicineAPI.Model.PacienteModel", "Paciente")
                        .WithMany("Exames")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LabMedicineAPI.Model.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("LabMedicineAPI.Model.ExercicioModel", b =>
                {
                    b.HasOne("LabMedicineAPI.Model.PacienteModel", "Paciente")
                        .WithMany("Exercicios")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LabMedicineAPI.Model.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("LabMedicineAPI.Model.MedicamentoModel", b =>
                {
                    b.HasOne("LabMedicineAPI.Model.PacienteModel", "Paciente")
                        .WithMany("Medicamentos")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LabMedicineAPI.Model.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("LabMedicineAPI.Model.PacienteModel", b =>
                {
                    b.HasOne("LabMedicineAPI.Model.UsuarioModel", "Usuario")
                        .WithMany("Pacientes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("LabMedicineAPI.Model.PacienteModel", b =>
                {
                    b.Navigation("Consultas");

                    b.Navigation("Dietas");

                    b.Navigation("Enderecos");

                    b.Navigation("Exames");

                    b.Navigation("Exercicios");

                    b.Navigation("Medicamentos");
                });

            modelBuilder.Entity("LabMedicineAPI.Model.UsuarioModel", b =>
                {
                    b.Navigation("Consultas");

                    b.Navigation("Pacientes");
                });
#pragma warning restore 612, 618
        }
    }
}
