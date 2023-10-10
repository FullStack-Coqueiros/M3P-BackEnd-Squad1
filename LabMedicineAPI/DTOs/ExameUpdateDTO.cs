using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.DTOs
{
    public class ExameUpdateDTO
    {
        [Required(ErrorMessage = "O campo 'NomeExame' é obrigatório.")]
        public string NomeExame { get; set; }
        
        [Required(ErrorMessage = "O campo 'Data' é obrigatório.")]
        public DateTime Data { get; set; }

         [Required(ErrorMessage = "O campo 'Horario' é obrigatório.")]
        public DateTime Horario { get; set; }
              
        [Required(ErrorMessage = "O campo 'TipoExame' é obrigatório.")]
        public string TipoExame { get; set; }

        [Required(ErrorMessage = "O campo 'Laboratorio' é obrigatório.")]
        public string Laboratorio { get; set; }

        public string URL { get; set; }

        [Required(ErrorMessage = "O campo 'Resultados' é obrigatório.")]
        public string Resultados { get; set; }

        [Required(ErrorMessage = "O campo 'StatusSistema' é obrigatório.")]
        public bool StatusSistema { get; set; }
        [Required]
        public int PacienteId { get; set; }
        [Required]
        public int UsuarioId { get; set; }
            
      
    }
}