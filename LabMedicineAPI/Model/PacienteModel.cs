using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LabMedicineAPI.Enums;
using System.ComponentModel.DataAnnotations;
using LabMedicineAPI.Base;

namespace LabMedicineAPI.Model
{
    [Table("Paciente")]
    public class PacienteModel : BaseUsuario
    {
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required, MaxLength(20)]
        public string RgOrgaoExpedidor { get; set; }
        [Required]
        public EstadoCivilEnum EstadoCivil { get; set; }
        public string Alergias { get; set; }
        public string CuidadosEspecificos { get; set; }
        public string Convenio { get; set; }
        public string NumeroConvenio { get; set; }
        public DateTime? ValidadeConvenio { get; set; }
        [Required]
        [ForeignKey("UsuarioModel")]
        public int UsuarioId { get; set; }
        [Required]
        public UsuarioModel Usuario { get; set; }
        public ICollection <ConsultaModel> Consultas { get; set; }
        public ICollection<DietaModel> Dietas { get; set; }
        public ICollection<ExameModel> Exames { get; set; }
        public ICollection<ExercicioModel> Exercicios { get; set;}
        public ICollection<MedicamentoModel> Medicamentos { get; set;}
        public ICollection<EnderecoModel> Enderecos { get; set; }


    }
}