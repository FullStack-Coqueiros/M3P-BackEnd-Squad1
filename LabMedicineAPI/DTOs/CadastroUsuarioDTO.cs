using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LabMedicineAPI.Enums;

namespace LabMedicineAPI.DTOs
{
    public class CadastroUsuarioDTO
    {
        [Required, MaxLength(64), MinLength(8)]
        public string NomeCompleto { get; set; }
        [Required]
        public GeneroEnum Genero { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public TipoEnum Tipo { get; set; }
        [Required]
        public bool StatusSistema { get; } = true;
    }
}