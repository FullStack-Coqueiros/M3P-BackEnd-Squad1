using LabMedicineAPI.Model;
using Microsoft.EntityFrameworkCore;


namespace LabMedicineAPI.Infra
{
    public class LabMedicineDbContext : DbContext
    {
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<PacienteModel> Pacientes { get; set; }
        public DbSet<ConsultaModel> Consultas { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }
        public DbSet<ExameModel> Exames { get; set; }
        public DbSet<ExercicioModel> Exercicios { get; set; }
        public DbSet<DietaModel> Dietas { get; set; }
        public DbSet<MedicamentoModel> Medicamentos { get; set; }



        public LabMedicineDbContext(DbContextOptions<LabMedicineDbContext> options) : base(options)
        {
        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ConsultaModel>()
                .HasOne(c => c.Paciente)
                .WithMany(p => p.Consultas)
                .HasForeignKey(c => c.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ConsultaModel>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.Consultas)
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DietaModel>()
                .HasOne(h => h.Paciente) 
                .WithMany(c => c.Dietas) 
                .HasForeignKey(p => p.PacienteId);

            modelBuilder.Entity<ExameModel>()
                .HasOne(h => h.Paciente) 
                .WithMany(c => c.Exames)
                .HasForeignKey(p => p.PacienteId);

            modelBuilder.Entity<MedicamentoModel>()
                .HasOne(h => h.Paciente)
                .WithMany(c => c.Medicamentos)
                .HasForeignKey(p => p.PacienteId);

            modelBuilder.Entity<PacienteModel>()
                .HasOne(p => p.Endereco)
                .WithOne(e => e.Paciente)
                .HasForeignKey<EnderecoModel>(e => e.PacienteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EnderecoModel>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<UsuarioModel>().HasData(

               new UsuarioModel
               {
                   Id = 1,
                   NomeCompleto = "4Devs",
                   Genero = "Outro",
                   CPF = "09465328956",
                   Email = "admin1@admin.com",
                   StatusSistema = true,
                   Telefone = "48998000054",
                   Senha = "12345678",
                   Tipo = "Administrador"
               },
               new UsuarioModel
               {
                   Id = 2,
                   NomeCompleto = "Rafael Silva",
                   Genero = "Masculino",
                   CPF = "45662548652",
                   Email = "rafael@gmail.com",
                   StatusSistema = true,
                   Telefone = "48995321544",
                   Senha = "12345678",
                   Tipo = "Médico"
               },
               new UsuarioModel
               {
                   Id = 3,
                   NomeCompleto = "Alessandra",
                   Genero = "Feminino",
                   CPF = "06532589965",
                   Email = "alessandra@gmail.com",
                   StatusSistema = true,
                   Telefone = "48995874233",
                   Senha = "12345678",
                   Tipo = "Enfermeiro"
               },
                new UsuarioModel
                {
                    Id = 4,
                    NomeCompleto = "William",
                    Genero = "Masculino",
                    CPF = "06523144785",
                    Email = "william84@gmail.com",
                    StatusSistema = true,
                    Telefone = "48996524233",
                    Senha = "12345678",
                    Tipo = "Enfermeiro"
                }
               );
            modelBuilder.Entity<PacienteModel>().HasData(
               new PacienteModel
               {
                   Id = 1,
                   NomeCompleto = "Amanda Siqueira",
                   Genero = "Feminino",
                   CPF = "09856326588",
                   Email = "amandasq95@gmail.com",
                   StatusSistema = true,
                   DataNascimento = new DateTime(1980, 5, 15),
                   RgOrgaoExpedidor = "1234567",
                   EstadoCivil = "Casado",
                   Telefone = "(11) 555-1234",
                   Naturalidade = "São Paulo, SP",
                   ContatoEmergencia = "48996325484",
                   Alergias = "Nenhuma alergia conhecida",
                   CuidadosEspecificos = "Nenhum cuidado específico",
                   Convenio = "Plano de Saúde ABC",
                   NumeroConvenio = "98765432",
                   ValidadeConvenio = new DateTime(2024, 12, 31)
               });
            for (int i = 1; i <= 10; i++)
            {
                modelBuilder.Entity<PacienteModel>().HasData(
                    new PacienteModel
                    {
                        Id = 1+i++,
                        NomeCompleto = $"Paciente {i}",
                        Genero = i % 2 == 0 ? "Feminino" : "Masculino",
                        CPF = "09856326588",
                        Email = $"paciente{i}@example.com",
                        StatusSistema = true,
                        DataNascimento = new DateTime(1980, 5, 15).AddYears(i),
                        RgOrgaoExpedidor = "1234567",
                        EstadoCivil = i % 2 == 0 ? "Casado" : "Solteiro",
                        Telefone = "(11) 555-1234",
                        Naturalidade = "São Paulo, SP",
                        ContatoEmergencia = "48996325484",
                        Alergias = "Nenhuma alergia conhecida",
                        CuidadosEspecificos = "Nenhum cuidado específico",
                        Convenio = "Plano de Saúde ABC",
                        NumeroConvenio = "98765432",
                        ValidadeConvenio = new DateTime(2024, 12, 31)
                    });
            }
            for (int i = 1; i <= 15; i++)
            {
                int pacienteId = i % 10 + 1;
                int usuarioId = (i % 3) + 2; 

                modelBuilder.Entity<ConsultaModel>().HasData(
                    new ConsultaModel
                    {
                        Id = i,
                        MotivoConsulta = $"Motivo da Consulta {i}",
                        Data = DateTime.Now.AddDays(-i),
                        Horario = DateTime.Now.AddHours(-i),
                        ProblemaDescricao = $"Descrição do problema para Consulta {i}",
                        MedicacaoIndicada = "Medicação Indicada",
                        DosagemEPrecaucoes = "Dosagem e Precauções",
                        StatusSistema = true,
                        PacienteId = 1,
                        UsuarioId = 2
                    });
            }
            for (int i = 1; i <= 25; i++)
            {
                

                modelBuilder.Entity<ExameModel>().HasData(
                    new ExameModel
                    {
                        Id = i,
                        NomeExame = $"Exame {i}",
                        Data = DateTime.Now.AddDays(-i),
                        Horario = DateTime.Now.AddHours(-i),
                        TipoExame = "Tipo de Exame",
                        Laboratorio = "Laboratório XYZ",
                        Url = $"http://www.laboratorioxyz.com/exames/exame-{i}",
                        Resultados = "Resultados do exame",
                        StatusSistema = true,
                        PacienteId = 1,
                        UsuarioId = 2,
                    });
            }

            //modelBuilder.Entity<EnderecoModel>().HasData(
            // new EnderecoModel
            // {
         
               
            //     CEP = "54321-987",
            //     Cidade = "Rio de Janeiro",
            //     Estado = "RJ",
            //     Logradouro = "Rua Copacabana",
            //     Numero = "789",
            //     Complemento = "Casa 1",
            //     Bairro = "Copacabana",
            //     PontoReferencia = "Próximo à praia",
            //     PacienteId = 3,
            // });

            //modelBuilder.Entity<EnderecoModel>().HasData(
            //    new EnderecoModel
            //    {
                    
            //        CEP = "98765-432",
            //        Cidade = "Belo Horizonte",
            //        Estado = "MG",
            //        Logradouro = "Avenida Central",
            //        Numero = "4567",
            //        Complemento = "Sala 302",
            //        Bairro = "Centro",
            //        PontoReferencia = "Próximo à praça principal",
            //        PacienteId = 4,
            //    });

            //modelBuilder.Entity<EnderecoModel>().HasData(
            //    new EnderecoModel
            //    {
                    
            //        CEP = "56789-012",
            //        Cidade = "Curitiba",
            //        Estado = "PR",
            //        Logradouro = "Rua Curitiba",
            //        Numero = "987",
            //        Complemento = "Bloco 5",
            //        Bairro = "Centro",
            //        PontoReferencia = "Próximo à estação de ônibus",
            //        PacienteId = 5,
            //    });

            //modelBuilder.Entity<EnderecoModel>().HasData(
            //    new EnderecoModel
            //    {
                  
            //        CEP = "65432-109",
            //        Cidade = "Porto Alegre",
            //        Estado = "RS",
            //        Logradouro = "Avenida Porto Alegre",
            //        Numero = "3210",
            //        Complemento = "Sala 10A",
            //        Bairro = "Centro",
            //        PontoReferencia = "Próximo ao teatro",
            //        PacienteId = 6,
            //    });

            //modelBuilder.Entity<EnderecoModel>().HasData(
            //    new EnderecoModel
            //    {
                    
            //        CEP = "23456-789",
            //        Cidade = "Recife",
            //        Estado = "PE",
            //        Logradouro = "Rua Recife",
            //        Numero = "1234",
            //        Complemento = "Apt 5C",
            //        Bairro = "Boa Viagem",
            //        PontoReferencia = "Próximo à praia",
            //        PacienteId = 7,
            //    });

            //modelBuilder.Entity<EnderecoModel>().HasData(
            //    new EnderecoModel
            //    {
                    
            //        CEP = "76543-210",
            //        Cidade = "Salvador",
            //        Estado = "BA",
            //        Logradouro = "Avenida Salvador",
            //        Numero = "555",
            //        Complemento = "Loja 1",
            //        Bairro = "Centro",
            //        PontoReferencia = "Próximo ao mercado",
            //        PacienteId = 8,
            //    });

            //modelBuilder.Entity<EnderecoModel>().HasData(
            //    new EnderecoModel
            //    {
                    
            //        CEP = "89012-345",
            //        Cidade = "Fortaleza",
            //        Estado = "CE",
            //        Logradouro = "Rua Fortaleza",
            //        Numero = "9876",
            //        Complemento = "Casa 3",
            //        Bairro = "Aldeota",
            //        PontoReferencia = "Próximo à praça",
            //        PacienteId = 9,
            //    });

            //modelBuilder.Entity<EnderecoModel>().HasData(
            //    new EnderecoModel
            //    {
                    
            //        CEP = "32198-765",
            //        Cidade = "Natal",
            //        Estado = "RN",
            //        Logradouro = "Avenida Natal",
            //        Numero = "12345",
            //        Complemento = "Apt 10B",
            //        Bairro = "Ponta Negra",
            //        PontoReferencia = "Próximo à praia",
            //        PacienteId = 10,
            //    });

            for (int i = 1; i <= 25; i++)
            {
                int pacienteId = i % 10 + 1;
                int usuarioId = (i % 3) + 2;

                modelBuilder.Entity<DietaModel>().HasData(
                new DietaModel
                {
                    Id = i,
                    NomeDieta = "Dieta Low Carb",
                    DescricaoDieta = "Dieta com baixa ingestão de carboidratos",
                    Data = DateTime.Now.AddDays(-i),
                    Horario = DateTime.Now.AddHours(-i),
                    TipoDieta = "lowCarb",
                    PacienteId = 5,
                    UsuarioId = 3,
                    StatusSistema = true
                });
            };
            for (int i = 1; i <= 25; i++)
            {
                int pacienteId = i % 10 + 1;
                int usuarioId = (i % 3) + 2;

                modelBuilder.Entity<ExercicioModel>().HasData(
                new ExercicioModel
                {
                    Id = i,
                    NomeSerieExerc = "Exercícios de Resistência Aeróbica",
                    Data = DateTime.Now.AddDays(-i),
                    Horario = DateTime.Now.AddHours(-i),
                    TipoExerc = "Resistência_aerobica",
                    QuantidadeSemana = (+i),
                    DescricaoExerc = "Série de exercícios aeróbicos para melhorar resistência",
                    PacienteId = 8,
                    UsuarioId = 4,
                    StatusSistema = true
                });
            };
            for (int i = 1; i <= 25; i++)
            {
                int pacienteId = i % 10 + 1;
                int usuarioId = (i % 3) + 2;

                modelBuilder.Entity<MedicamentoModel>().HasData(
                new MedicamentoModel
                {
                    Id = i,
                    NomeMedicamento = "Medicamento 1",
                    Data = DateTime.Now.AddDays(i),
                    TipoMedicamento = "cápsula",
                    Quantidade = 10,
                    Observacoes = $"Observações do medicamento {+i}",
                    StatusSistema = true,
                    Unidade = "mg",
                    PacienteId = 15,
                    UsuarioId = 2
                });
            }

   

            base.OnModelCreating(modelBuilder);

        }

    }
}
