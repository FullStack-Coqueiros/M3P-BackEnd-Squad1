using LabMedicineAPI.Enums;

namespace LabMedicineAPI.DTOs.Dieta
{
    public class DietaGetDTO
    {
        public string NomeDieta { get; set; }
        public string? DescricaoDieta { get; set; }
        public DateTime Data { get; set; }
        public DateTime Horario { get; set; }
        public TipoDietaEnum TipoDieta { get; set; }
        public string? DescricaoDetalhada { get; set; }
        public bool StatusSistema { get; set; } = true;
        public int PacienteId { get; set; }
        public int UsuarioId { get; set; }

    }



}