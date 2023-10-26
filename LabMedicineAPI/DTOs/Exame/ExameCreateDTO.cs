using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.DTOs.Exame
{
    public class ExameCreateDTO
    {
        [Required(ErrorMessage = "O Nome do Exame é obrigatório")]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "O Nome do Exame deve ter entre 8 e 64 caracteres.")]
        public string NomeExame { get; set; }

        [Required(ErrorMessage = "A Data do Exame é obrigatória.")]
        public DateTime Data { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "O Horário do Exame é obrigatório.")]
        public DateTime Horario { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "O Tipo do Exame é obrigatório.")]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "O Tipo do Exame deve conter entre 4 e 32 caracteres.")]
        public string TipoExame { get; set; }

        [Required(ErrorMessage = "O Laboratório é obrigatório.")]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "O Tipo do Exame deve conter entre 4 e 32 caracteres.")]
        public string Laboratorio { get; set; }

        public string? Url { get; set; }

        [Required(ErrorMessage = "Os Resultados são obrigatórios.")]
        [StringLength(1024, MinimumLength = 16, ErrorMessage = "Os Resultados devem ter entre 16 e 1024 caracteres.")]
        public  string Resultados { get; set; }

        [Required(ErrorMessage = "O Status do Sistema é obrigatório.")]
        public bool StatusSistema { get; set; }

        [Required(ErrorMessage = "O Id do Paciente é obrigatório.")]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "O Id do Médico é Obrigatório.")]
        public int UsuarioId { get; set; }


    }
}