using System.ComponentModel.DataAnnotations;
using LabMedicineAPI.Enums;

namespace LabMedicineAPI.DTOs.Dieta
{
    public class DietaCreateDTO
    {
        [Required(ErrorMessage = "O preenchimento do campo nome da dieta é obrigatório.")]
        [StringLength(100, MinimumLength = 5)]
        public string NomeDieta { get; set; }
        public string? DescricaoDieta { get; set; }
        [Required(ErrorMessage = "O preenchimento do campo data é obrigatório.")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "O preenchimento do campo horario é obrigatório.")]
        public DateTime Horario { get; set; }
        [Required(ErrorMessage = "O preenchimento do campo tipo de dieta é obrigatório.")]
        public TipoDietaEnum TipoDieta { get; set; }
        public string? DescricaoDetalhada { get; set; }
        [Required(ErrorMessage = "O preenchimento do campo status no sistema é obrigatório.")]
        public bool StatusSistema { get; set; } = true;
        [Required(ErrorMessage = "O preenchimento do paciente id é obrigatório.")]
        public int PacienteId { get; set; }
        [Required(ErrorMessage = "O preenchimento do campo usuario id é obrigatório.")]
        public int UsuarioId { get; set; }

    }



}