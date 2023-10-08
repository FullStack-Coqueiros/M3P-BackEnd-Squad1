using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LabMedicineAPI.Enums;

namespace LabMedicineAPI.DTOs
{
    public class UsuarioGetDTO
    {
        public int UsuarioId { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Tipo { get; set; }
        public bool StatusSistema { get; set; }

        public UsuarioGetDTO(int usuarioId, string nomeCompleto, string email, string tipo, bool statusDoSistema)
        {
            UsuarioId = usuarioId;
            NomeCompleto = nomeCompleto;
            Email = email;
            Tipo = tipo;
            StatusSistema = statusDoSistema;
            
        }
    }
}