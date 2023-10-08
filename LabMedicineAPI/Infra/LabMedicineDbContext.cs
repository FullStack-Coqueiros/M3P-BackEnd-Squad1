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
                .HasOne(h => h.Paciente) // Um paciente pode ter muitos consulta
                .WithMany(c => c.Consultas) // Um paciente muitas consultas
                .HasForeignKey(p => p.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DietaModel>()
                .HasOne(h => h.Paciente) // Um paciente pode ter muitos dietas
                .WithMany(c => c.Dietas) // Um paciente muitas consultas
                .HasForeignKey(p => p.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExameModel>()
                .HasOne(h => h.Paciente) // Um paciente pode ter muitos dietas
                .WithMany(c => c.Exames) // Um paciente muitas 
                .HasForeignKey(p => p.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MedicamentoModel>()
                .HasOne(h => h.Paciente)
                .WithMany(c => c.Medicamentos)
                .HasForeignKey(p => p.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EnderecoModel>()
               .HasOne(h => h.Paciente)
               .WithMany(c => c.Enderecos)
               .HasForeignKey(p => p.PacienteId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PacienteModel>()                
                .HasOne(h => h.Usuario)
                .WithMany(c => c.Pacientes)
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            ///

            //modelBuilder.Entity<UsuarioModel>()
            //            .HasOne(h => h.Pacientes) // Um usuário pode ter muitos pacientes
            //            .WithMany(w => w.Id) // Um paciente pertence a um único usuário
            //            .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Endereco>()
            //            .Property(p => p.DataCadastro)
            //            .HasDefaultValueSql("GETDATE()");

            //modelBuilder.Entity<ConsultaModel>()
                       

            //modelBuilder.Entity<ExameModel>()
            //            .Property(p => p.DataCadastro)
            //            .HasDefaultValueSql("GETDATE()");

            //modelBuilder.Entity<ExercicioModel>()
            //            .Property(p => p.DataCadastro)
            //            .HasDefaultValueSql("GETDATE()");

            //modelBuilder.Entity<DietaModel>()
            //            .Property(p => p.DataCadastro)
            //            .HasDefaultValueSql("GETDATE()");

            //modelBuilder.Entity<MedicamentoModel>()
            //            .Property(p => p.DataCadastro)
            //            .HasDefaultValueSql("GETDATE()");

            //modelBuilder.Entity<UsuarioModel>()
            //           .HasMany(usuario => usuario.Pacientes) // Um usuário pode ter muitos pacientes
            //           .WithOne(paciente => paciente.Usuario) // Um paciente pertence a um único usuário
            //           .HasForeignKey(paciente => paciente.UsuarioId)
            //           .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);

        }

    }
}
