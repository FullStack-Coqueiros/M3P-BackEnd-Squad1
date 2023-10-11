using System.ComponentModel.DataAnnotations;
using LabMedicineAPI.Enums;

namespace LabMedicineAPI.DTOs.Medicamento
{
    public class MedicamentoUpdateDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string NomeMedicamento { get; set; }

        [Required]
        public DateTime Data { get; set; }
        [Required]
        public DateTime Horario { get; set; }
        [Required]
        public TipoMedicamentoEnum TipoMedicamento { get; set; }
        [Required]
        public decimal Quantidade { get; set; }
        [Required]
        public UnidadeEnum Unidade { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 10)]
        public string Observacoes { get; set; }
        [Required]
        public bool StatusSistema { get; set; } = true;
        public int UsuarioId { get; set; }
        public int PacienteId { get; set; }

    }
}
