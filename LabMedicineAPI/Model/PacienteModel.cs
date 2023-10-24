
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LabMedicineAPI.Enums;
using System.ComponentModel.DataAnnotations;
using LabMedicineAPI.Base;
using System.Diagnostics.CodeAnalysis;
using System.Collections.ObjectModel;

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

        [Column(TypeName = "VARCHAR"), Required, MaxLength(255)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "A Naturalidade é obrigatória.")]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "A Naturalidade deve ter entre 8 e 64 caracteres.")]
        public  string Naturalidade { get; set; }
        [Column(TypeName = "VARCHAR"), MaxLength(255)]
        public string Alergias { get; set; }
        [Column(TypeName = "VARCHAR"), MaxLength(255)]
        public string CuidadosEspecificos { get; set; }
        [Column(TypeName = "VARCHAR"), MaxLength(255)]

        public string Convenio { get; set; }
        [Column(TypeName = "VARCHAR"), MaxLength(255), Required]
        public string ContatoEmergencia { get; set; }
        [Column(TypeName = "VARCHAR"), MaxLength(255)]
        public string NumeroConvenio { get; set; }
        public DateTime? ValidadeConvenio { get; set; }
        public virtual EnderecoModel Endereco { get; set; }
        public virtual Collection<ConsultaModel> Consultas { get; set; }
        public virtual Collection<DietaModel> Dietas { get; set; }
        public  virtual Collection<ExameModel> Exames { get; set; }
        public virtual Collection<ExercicioModel> Exercicios { get; set; }
        public virtual Collection<MedicamentoModel> Medicamentos { get; set; }


    }
}