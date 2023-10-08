using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LabMedicineAPI.Enums;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.DTOs
{
    public class AtualizacaoPacienteDTO
    {
        [Required, MaxLength(64), MinLength(8)]
        public string NomeCompleto { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public EstadoCivilEnum EstadoCivil { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required, MaxLength(64), MinLength(8)]
        public string Naturalidade { get; set; }
        [Required]
        public string ContatoEmergencia { get; set; }
        public string Alergias { get; set; }
        public string CuidadosEspecificos { get; set; }
        public string Convenio { get; set; }
        public string NumeroConvenio { get; set; }
        public DateTime ValidadeConvenio { get; set; }
        [Required]
        public Endereco Endereco { get; set; }
        [Required]
        public bool StatusSistema { get; set; }
    }
}