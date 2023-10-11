using LabMedicineAPI.Enums;

namespace LabMedicineAPI.DTOs.Medicamento
{
    public class MedicamentoGetDTO
    {
        public string NomeMedicamento { get; set; }
        public decimal Quantidade { get; set; }
        public UnidadeEnum Unidade { get; set; }
        public TipoMedicamentoEnum TipoMedicamento { get; set; }
        public int UsuarioId { get; set; }
        public int PacienteId { get; set; }
        public bool StatusSistema { get; set; } = true;
        public string Observacoes { get; set; }

    }
}
