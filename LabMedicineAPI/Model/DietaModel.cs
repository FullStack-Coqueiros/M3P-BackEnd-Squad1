using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LabMedicineAPI.Enums;

namespace LabMedicineAPI.Model
{
    [Table("Dieta")]
    public class DietaModel
    {
       [Column(TypeName = "VARCHAR"), Required, MaxLength(100), MinLength(5)]
       public string NomeDieta { get; set; } 

       public string DescricaoDieta { get; set; }

       [Required]
       public DateTime Data { get; set; }

       [Required]
       public DateTime Horario { get; set; }

       [Required]
       public TipoDietaEnum TipoDieta { get; set; }

       //ver com Vitor, tem 2 prop Descriçao mesmo ou é erro na documentação?

       [Column(TypeName = "VARCHAR"), Required]
       public bool StatusSistema { get; } = true;

       [Required]
       [ForeignKey("Paciente Model")]
       public int PacienteId { get; set; }

       [Required]
       public PacienteModel paciente { get; set; }

       [Required]
       [ForeignKey("Usuario Model")]
       public int UsuarioId { get; set; }
        
       [Required]
       public UsuarioModel usuario { get; set; }     

    }
}