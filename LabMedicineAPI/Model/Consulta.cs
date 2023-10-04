using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabMedicineAPI.Model
{
    [Table("Consulta")]
    public class Consulta
    {
        [Column(TypeName = "VARCHAR"), Required, MaxLength(64), MinLength(8)]
        public string MotivoConsulta { get; set; }
        [Required]
        public DateTime DataConsulta { get; set; }
        [Required]
        public DateTime HorarioConsulta { get; set; }
        [Column(TypeName = "VARCHAR"), Required, MaxLength(500), MinLength(90)]
        public string ProblemaDescricao { get; set; }

        [Column(TypeName = "VARCHAR"), Required, MaxLength(1024), MinLength(16)]
        public string MedicacaoIndicada { get; set; }
        [Column(TypeName = "VARCHAR"), Required, MaxLength(256), MinLength(16)]
        public string DosagemEPrecaucoes { get; set; }
        [Required]
        public bool StatusDoSistema { get; set; }
        [Required]
        public int PacienteId { get; set; }
        [Required]
        public PacienteModel paciente { get; set; }
        public int UsuarioId { get; set; }
        [Required]
        public UsuarioModel usuario { get; set; }
    }
}
