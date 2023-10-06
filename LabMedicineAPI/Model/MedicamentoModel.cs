using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LabMedicineAPI.Enums;

namespace LabMedicineAPI.Model
{
    [Table("Medicamento")]
    public class MedicamentoModel
    {
        [Column(TypeName = "VARCHAR"), Required, MaxLength(100), MinLength(5)]
        public string NomeMedicamento { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public DateTime Horario { get; set; }

        [Required]
        public TipoMedicamentoEnum TipoMedicamento { get; set; }

        [Required]
        public decimal Quantidade { get; set; }

        [Required]
        public UnidadeEnum Unidade { get; set; }

        [Column(TypeName = "VARCHAR"), Required, MaxLength(1000), MinLength(10)]
        public string Observacoes { get; set; }

        [Required]
        public bool StatusSistema { get; set; }

        [Required]
        [ForeignKey("PacienteModel")]
        public int PacienteId { get; set; }

        [Required]
        public PacienteModel paciente { get; set; }

        [Required]
        [ForeignKey("UsuarioModel")]
        public int UsuarioId { get; set; }
        
        [Required]
        public UsuarioModel usuario { get; set; }
    }
}