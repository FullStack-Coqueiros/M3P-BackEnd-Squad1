using System.ComponentModel.DataAnnotations;
using LabMedicineAPI.Enums;

namespace LabMedicineAPI.DTOs.Medicamento
{
    public class MedicamentoCreateDTO
    {
        [Required(ErrorMessage = "O campo nome é de preenchimento obrigatório.")]
        [StringLength(100, MinimumLength = 5)]
        public string NomeMedicamento { get; set; }

        [Required(ErrorMessage = "O campo data é de preenchimento obrigatório.")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "O campo horario é de preenchimento obrigatório.")]
        public DateTime Horario { get; set; }
        [Required]
        public TipoMedicamentoEnum TipoMedicamento { get; set; }
        [Required(ErrorMessage = "O campo quantidade é de preenchimento obrigatório.")]
        public decimal Quantidade { get; set; }
        [Required(ErrorMessage = "O campo unidade é de preenchimento obrigatório.")]
        public UnidadeEnum Unidade { get; set; }
        [Required(ErrorMessage = "O campo observacoes é de preenchimento obrigatório.")]
        [StringLength(1000, MinimumLength = 10)]
        public string Observacoes { get; set; }
        [Required(ErrorMessage = "O campo status do sistema é de preenchimento obrigatório.")]
        public bool StatusSistema { get; set; } = true;
        public int UsuarioId { get; set; }
        public int PacienteId { get; set; }

    }
}
