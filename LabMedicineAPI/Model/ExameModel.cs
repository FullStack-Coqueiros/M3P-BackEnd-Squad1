using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LabMedicineAPI.Model
{
    [Table("Exame")]
    public class ExameModel
    {
        [Column(TypeName = "VARCHAR"), Required, MaxLength(64), MinLength(8)]
        public string NomeExame { get; set; }
        
        [Required]
        public DateTime Data { get; set; }

        [Required]
        public DateTime Horario { get; set; }
              
        [Column(TypeName = "VARCHAR"), Required, MaxLength(32), MinLength(4)]
        public string TipoExame { get; set; }

        [Column(TypeName = "VARCHAR"), Required, MaxLength(32), MinLength(4)]
        public string Laboratorio { get; set; }

        public string URL { get; set; }

        [Column(TypeName = "VARCHAR"), Required, MaxLength(1024), MinLength(16)]
        public string Resultados { get; set; }

        [Required]
        public bool StatusSistema { get; set; }

        [Required]
        [ForeignKey("Paciente Model")]
        public int PacienteId { get; set; }

        [Required]
        public PacienteModel Paciente { get; set; }

        [Required]
        [ForeignKey("Usuario Model")]
        public int UsuarioId { get; set; }

        [Required]
        public UsuarioModel Usuario { get; set; }

    }
}