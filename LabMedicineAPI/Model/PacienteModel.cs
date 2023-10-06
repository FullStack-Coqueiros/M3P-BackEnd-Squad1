using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LabMedicineAPI.Enums;
using LabMedicineAPI.Model;
using System.ComponentModel.DataAnnotations;

namespace LabMedicineAPI.Model
{
    [Table("Paciente")]
    public class PacienteModel : UsuarioModel
    {
        [Required]
        public DateTime DataNascimento { get; set; }
        [Column(TypeName = "VARCHAR"), Required, RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$")]
        public string RgOrgaoExpedidor { get; set; }
        [Required]
        public EstadoCivilEnum EstadoCivil { get; set; }
        public string Alergias { get; set; }
        public string CuidadosEspecificos { get; set; }
        public string Convenio { get; set; }
        public string NumeroConvenio { get; set; }
        public DateTime? ValidadeConvenio { get; set; }
        [Required]
        public Endereco Endereco { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public UsuarioModel usuario { get; set; }
    }
}