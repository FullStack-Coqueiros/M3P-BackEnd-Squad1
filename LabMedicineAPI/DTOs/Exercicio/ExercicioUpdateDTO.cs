using System.ComponentModel.DataAnnotations;
using LabMedicineAPI.Enums;

namespace LabMedicineAPI.DTOs.Exercicio
{
    public class ExercicioUpdateDTO
    {
        [Required(ErrorMessage = "O preenchimento do campo nome da serie de exercicios é obrigatório.")]
        [StringLength(100, MinimumLength = 5)]
        public string NomeSerieExerc { get; set; }
        [Required(ErrorMessage = "O preenchimento do campo data é obrigatório.")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "O preenchimento do campo horario é obrigatório.")]
        public DateTime Horario { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo tipo de exercicio é obrigatório.")]
        public TipoExercicioEnum Tipo { get; set; }

        [Required(ErrorMessage = "O preenchimento do quantidade por semana é obrigatório.")]
        public decimal QuantidadeSemana { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo descrição é obrigatório.")]
        [StringLength(1000, MinimumLength = 10)]
        public string Descricao { get; set; }
        public int PacienteId { get; set; }
        [Required(ErrorMessage = "O preenchimento do campo usuarioid é obrigatório.")]
        public int UsuarioId { get; set; }
    }


}