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
        public string Email { get; set; }
        public TipoEnum Tipo { get; set; }
        public bool StatusSistema { get; set; } = true;

    }
}