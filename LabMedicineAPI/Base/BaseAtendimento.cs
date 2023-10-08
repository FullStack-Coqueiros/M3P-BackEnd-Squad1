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
        public DateTime Data { get; set; } //Usar a prop .formenber noa uato mapper para renomear a prop conforme a dto e exigencia do projeto no request.
        [Required]
        public DateTime Horario { get; set; } //Usar a prop .formenber noa uato mapper para renomear a prop conforme a dto e exigencia do projeto no request.

        [Required]
        public bool StatusSistema { get; set; }=true;
        [Required]
        [ForeignKey("PacienteModel")]
        public int PacienteId { get; set; }
        [Required]
        public PacienteModel Paciente { get; set; }
        [Required]
        [ForeignKey("UsuarioModel")]
        public int UsuarioId { get; set; }
        [Required]
        public UsuarioModel Usuario { get; set; }

    }
}
