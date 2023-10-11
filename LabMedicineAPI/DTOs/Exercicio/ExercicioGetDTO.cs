using LabMedicineAPI.Enums;

namespace LabMedicineAPI.DTOs.Exercicio
{
    public class ExercicioGetDTO
    {
        public string NomeSerieExerc { get; set; }
        public DateTime Data { get; set; }
        public DateTime Horario { get; set; }
        public TipoExercicioEnum Tipo { get; set; }
        public decimal QuantidadeSemana { get; set; }
        public string Descricao { get; set; }
        public bool StatusSistema { get; set; } = true;
        public int PacienteId { get; set; }
        public int UsuarioId { get; set; }
    }


}