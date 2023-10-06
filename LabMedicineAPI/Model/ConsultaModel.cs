using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LabMedicineAPI.Model
{
    public class ConsultaModel
    {
        [Column(TypeName = "VARCHAR"), Required, MaxLength(64), MinLength(8)]
        public string MotivoConsulta { get; set; }
        [Required]
        public DateTime DataConsulta { get; set; }
        [Required]
        public DateTime HorarioConsulta { get; set; }
        [Column(TypeName = "VARCHAR"), Required, MaxLength(1024), MinLength(16)]
        public string ProblemaDescricao { get; set; }
        public string? MedicacaoIndicada { get; set; }
        [Column(TypeName = "VARCHAR"), Required, MaxLength(256), MinLength(16)]
        public string DosagemEPrecaucoes { get; set; }
        [Required]
        public bool StatusDoSistema { get; set; }
        public int PacienteId { get; set; }
        [Required]
        public PacienteModel Paciente { get; set; }
        public int UsuarioId { get; set; }
        [Required]
        public UsuarioModel Usuario { get; set; }
    }
}
