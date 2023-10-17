using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LabMedicineAPI.Enums;

namespace LabMedicineAPI.DTOs.Usuario
{
    public class UsuarioCreateDTO
    {
        [Required(ErrorMessage = "O Nome Completo é obrigatório.")]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "O Nome Completo deve ter entre 8 e 64 caracteres.")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O Gênero é obrigatório.")]
        public GeneroEnum Genero { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Formato de CPF inválido.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O Telefone é obrigatório.")]
        [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "Formato de Telefone inválido.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de E-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "A Senha deve ter no mínimo 6 caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O Tipo é obrigatório.")]
        [EnumDataType(typeof(TipoEnum), ErrorMessage = "Tipo de usuário inválido.")]
        public TipoEnum Tipo { get; set; }

        public bool StatusSistema { get; set; } = true; // Valor padrão: ativo

    }
}