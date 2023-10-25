using LabMedicineAPI.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabMedicineAPI.Base
{
    public class BaseAtendimento
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Data { get; set; } 
        [Required]
        public DateTime Horario { get; set; } 
        [Required]
        public bool StatusSistema { get; set; }=true;
        [Required]
        [ForeignKey("PacienteModel")]
        public int PacienteId { get; set; }
        [Required]
        public virtual PacienteModel Paciente { get; set; }
        [Required]
        [ForeignKey("UsuarioModel")]
        public int UsuarioId { get; set; }
        [Required]
        public virtual UsuarioModel Usuario { get; set; }

    }
}
