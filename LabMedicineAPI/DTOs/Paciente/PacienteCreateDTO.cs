using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LabMedicineAPI.DTOs.Endereco;
using LabMedicineAPI.Enums;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.DTOs.Paciente
{
    public class PacienteCreateDTO
    {
        [Required(ErrorMessage = "O Nome Completo é obrigatório.")]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "O Nome Completo deve ter entre 8 e 64 caracteres.")]
        public required string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O Gênero é obrigatório.")]
        public GeneroEnum Genero { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Formato de CPF inválido.")]
        public required string CPF { get; set; }

        [Required(ErrorMessage = "O RG com órgão expedidor é obrigatório.")]
        [StringLength(20, ErrorMessage = "O RG com órgão expedidor deve ter no máximo 20 caracteres.")]
        public required string RgOrgaoExpedidor { get; set; }

        [Required(ErrorMessage = "O Estado Civil é obrigatório.")]
        public EstadoCivilEnum EstadoCivil { get; set; }

        [Required(ErrorMessage = "O Telefone é obrigatório.")]
        [RegularExpression(@"^\(\d{2}\) \d{1,5}-\d{4,5}$", ErrorMessage = "Formato de Telefone inválido.")]
        public required string Telefone { get; set; }

        [Required(ErrorMessage = "O E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de E-mail inválido.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "A Naturalidade é obrigatória.")]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "A Naturalidade deve ter entre 8 e 64 caracteres.")]
        public required string Naturalidade { get; set; }

        [Required(ErrorMessage = "O Contato de Emergência é obrigatório.")]
        [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4,5}$", ErrorMessage = "Formato de Contato de Emergência inválido.")]
        public required string ContatoEmergencia { get; set; }

        public string? Alergias { get; set; }
        public string? CuidadosEspecificos { get; set; }
        public string? Convenio { get; set; }
        public string? NumeroConvenio { get; set; }

        public DateTime? ValidadeConvenio { get; set; }

        public required EnderecoCreateDTO Enderecos { get; set; }

        public bool StatusSistema { get; set; } = true;


    }
}