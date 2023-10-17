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
        public required string MotivoConsulta { get; set; }

        [Required(ErrorMessage = "A Data da Consulta é obrigatória.")]
        public DateTime Data { get; set; } 

        [Required(ErrorMessage = "O Horário da Consulta é obrigatório.")]
        public DateTime Horario { get; set; } 

        [Required(ErrorMessage = "A Descrição da Consulta é obrigatória.")]
        public required string ProblemaDescricao { get; set; }

        public string? MedicacaoIndicada { get; set; }

        [Required(ErrorMessage = "Dosagem e Precauções obrigatório.")]
        public string DosagemEPrecaucoes { get; set; }

        [Required]
        public int PacienteId { get; set; }
        
        [Required]
        public int UsuarioId { get; set; }
            
    }
}