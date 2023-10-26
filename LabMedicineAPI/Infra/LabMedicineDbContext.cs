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
                .HasOne(h => h.Paciente) // Um paciente pode ter muitos dietas
                .WithMany(c => c.Dietas) // Um paciente muitas consultas
                .HasForeignKey(p => p.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExameModel>()
                .HasOne(h => h.Paciente) // Um paciente pode ter muitos dietas
                .WithMany(c => c.Exames) // Um paciente muitas 
                .HasForeignKey(p => p.PacienteId);
            // .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MedicamentoModel>()
                .HasOne(h => h.Paciente)
                .WithMany(c => c.Medicamentos)
                .HasForeignKey(p => p.PacienteId);
                //.OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PacienteModel>()
                .HasOne(p => p.Endereco)
                .WithOne(e => e.Paciente)
                .HasForeignKey<EnderecoModel>(e => e.PacienteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EnderecoModel>()
                .HasKey(p => p.Id);


            base.OnModelCreating(modelBuilder);

        }

    }
}
