
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
        public required string Naturalidade { get; set; }
        public string Alergias { get; set; }
        public string CuidadosEspecificos { get; set; }
        public string Convenio { get; set; }
        [NotNull]
        public required string ContatoEmergencia { get; set; }
        public string NumeroConvenio { get; set; }
        public DateTime? ValidadeConvenio { get; set; }
        [Required]
        [ForeignKey("UsuarioModel")]
        public int UsuarioId { get; set; }
        [Required]
        public UsuarioModel Usuario { get; set; }
        public EnderecoModel Endereco { get; set; }

        public Collection <ConsultaModel> Consultas { get; set; }
        public Collection<DietaModel> Dietas { get; set; }
        public Collection<ExameModel> Exames { get; set; }
        public Collection<ExercicioModel> Exercicios { get; set;}
        public Collection<MedicamentoModel> Medicamentos { get; set;}
        public Collection<EnderecoModel> Enderecos { get; set; }


    }
}