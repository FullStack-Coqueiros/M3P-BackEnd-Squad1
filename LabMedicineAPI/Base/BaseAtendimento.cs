using LabMedicineAPI.Model;
using System.ComponentModel.DataAnnotations;

namespace LabMedicineAPI.Base
{
    public class BaseAtendimento
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PacienteId { get; set; }
        [Required]
        public PacienteModel Paciente { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public UsuarioModel Usuario { get; set; }

    }
}
