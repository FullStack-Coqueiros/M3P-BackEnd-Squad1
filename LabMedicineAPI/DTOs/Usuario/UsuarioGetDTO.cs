using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LabMedicineAPI.Enums;

namespace LabMedicineAPI.DTOs.Usuario
{
    public class UsuarioGetDTO
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Genero { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }
        public bool StatusSistema { get; set; } = true;

    }
}