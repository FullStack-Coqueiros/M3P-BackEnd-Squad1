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
        [StringLength(64, MinimumLength = 8, ErrorMessage = "O campo 'NomeExame' deve ter entre 8 e 64 caracteres.")]
        public string NomeExame { get; set; }
        
        [Required(ErrorMessage = "O campo 'Data' é obrigatório.")]
        public DateTime Data { get; set; }

         [Required(ErrorMessage = "O campo 'Horario' é obrigatório.")]
        public DateTime Horario { get; set; }
              
        [Required(ErrorMessage = "O campo 'TipoExame' é obrigatório.")]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "O campo 'TipoExame' deve ter entre 4 e 32 caracteres.")]
        public string TipoExame { get; set; }

        [Required(ErrorMessage = "O campo 'Laboratorio' é obrigatório.")]
        [StringLength(32, MinimumLength = 4, ErrorMessage = "O campo 'Laboratorio' deve ter entre 4 e 32 caracteres.")]
        public string Laboratorio { get; set; }

        public string URL { get; set; }

        [Required(ErrorMessage = "O campo 'Resultados' é obrigatório.")]
        [StringLength(1024, MinimumLength = 16, ErrorMessage = "O campo 'Resultados' deve ter entre 16 e 1024 caracteres.")]
        public string Resultados { get; set; }

        [Required(ErrorMessage = "O campo 'StatusSistema' é obrigatório.")]
        public bool StatusSistema { get; set; }
        [Required]
        public int PacienteId { get; set; }
        [Required]
        public int UsuarioId { get; set; }

       
        public ExameUpdateDTO(string nomeExame, DateTime data, DateTime horario, string tipoExame, string laboratorio, string resultados, bool statusSistema, int pacienteId, int usuarioId)
        {
            NomeExame = nomeExame;
            Data = data;
            Horario = horario;
            TipoExame = tipoExame;
            Laboratorio = laboratorio;
            Resultados = resultados; 
            StatusSistema = statusSistema;
            PacienteId = pacienteId;
            UsuarioId = usuarioId;                   
        }

      
    }
}