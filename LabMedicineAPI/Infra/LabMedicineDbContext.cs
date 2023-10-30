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
           
            base.OnModelCreating(modelBuilder);

        }

    }
}
