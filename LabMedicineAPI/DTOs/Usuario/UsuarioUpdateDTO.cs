using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LabMedicineAPI.Enums;

namespace LabMedicineAPI.DTOs.Usuario
{
    public class UsuarioUpdateDTO
    {
        [Required(ErrorMessage = "O campo 'NomeCompleto' é obrigatório.")]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "O campo 'NomeCompleto' deve ter entre 8 e 64 caracteres.")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O campo 'Genero' é obrigatório.")]
        public GeneroEnum Genero { get; set; }

        [Required(ErrorMessage = "O campo 'Telefone' é obrigatório.")]
        [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "Formato de 'Telefone' inválido.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo 'Senha' é obrigatório.")]
        [MinLength(6, ErrorMessage = "A 'Senha' deve ter no mínimo 6 caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo 'Tipo' é obrigatório.")]
        public TipoEnum Tipo { get; set; }

        public UsuarioUpdateDTO(string nomeCompleto, GeneroEnum genero, string telefone, string senha, TipoEnum tipo)
        {
            NomeCompleto = nomeCompleto;
            Genero = genero;
            Telefone = telefone;
            Senha = senha;
            Tipo = tipo;
        }
    }
}