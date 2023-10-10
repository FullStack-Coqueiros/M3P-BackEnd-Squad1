using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabMedicineAPI.DTOs
{
    public class ConsultaCreateDTO
    {
        [Required(ErrorMessage = "O Motivo da Consulta é obrigatório.")]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "O Motivo da Consulta deve ter entre 8 e 64 caracteres.")]
        public required string MotivoConsulta { get; set; }

         [Required(ErrorMessage = "A Data do Exame é obrigatória.")]
        public DateTime DataExame { get; set; } = DateTime.Now;
    }
}