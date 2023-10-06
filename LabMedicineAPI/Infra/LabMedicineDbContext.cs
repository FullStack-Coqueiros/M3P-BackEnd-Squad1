using LabMedicineAPI.Model;
using Microsoft.EntityFrameworkCore;


namespace LabMedicineAPI.Infra
{
    public class LabMedicineDbContext : DbContext
    {
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<PacienteModel>Pacientes { get; set; }
        public DbSet<ConsultaModel>Consultas { get; set; }
        public DbSet<Endereco>Enderecos { get; set; }
        public DbSet<ExameModel>Exames { get; set; }
        public DbSet<ExercicioModel>Exercicios { get; set; }
        public DbSet<DietaModel>Dietas { get; set; }
        public DbSet<MedicamentoModel>Medicamentos { get; set; }



        public LabMedicineDbContext(DbContextOptions<LabMedicineDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<ConsultaModel>()
                        .HasOne(h => h.Paciente) // Um usuário pode ter muitos pacientes
                        .WithMany(c => c.Consultas)
                        .HasForeignKey(p => p.PacienteId)
                        .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<UsuarioModel>()
                        .HasOne(h => h.Pacientes) // Um usuário pode ter muitos pacientes
                        .WithMany(w => w.Id) // Um paciente pertence a um único usuário
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Endereco>()
                        .Property(p => p.DataCadastro)
                        .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<ConsultaModel>()
                        .Property(p => p.DataCadastro)
                        .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<ExameModel>()
                        .Property(p => p.DataCadastro)
                        .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<ExercicioModel>()
                        .Property(p => p.DataCadastro)
                        .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<DietaModel>()
                        .Property(p => p.DataCadastro)
                        .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<MedicamentoModel>()
                        .Property(p => p.DataCadastro)
                        .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<UsuarioModel>()
                       .HasMany(usuario => usuario.Pacientes) // Um usuário pode ter muitos pacientes
                       .WithOne(paciente => paciente.Usuario) // Um paciente pertence a um único usuário
                       .HasForeignKey(paciente => paciente.UsuarioId)
                       .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);

        }

    }
}
