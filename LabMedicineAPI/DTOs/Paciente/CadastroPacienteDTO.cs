using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LabMedicineAPI.Enums;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.DTOs.Paciente
{
    public class CadastroPacienteDTO
    {
        [Required, MaxLength(64), MinLength(8)]
        public string NomeCompleto { get; set; }
        [Required]
        public GeneroEnum Genero { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string RgOrgaoExpedidor { get; set; }
        [Required]
        public EstadoCivilEnum EstadoCivil { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Naturalidade { get; set; }
        [Required]
        public string ContatoEmergência { get; set; }
        public string Alergias { get; set; }
        public string CuidadosEspecíficos { get; set; }
        public string Convenio { get; set; }
        public string ValidadeConvenio { get; set; }
        [Required]
        public EnderecoModel Endereco { get; set; }
        [Required]
        public bool StatusSistema { get; } = true;
    }
}