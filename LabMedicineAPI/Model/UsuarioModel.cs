using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LabMedicineAPI.Base;
using LabMedicineAPI.Enums;

namespace LabMedicineAPI.Model
{
    [Table("Usuario")]
    public class UsuarioModel : BaseUsuario
    {
        [Column(TypeName = "VARCHAR"), Required, MaxLength(13)]
        public string Telefone { get; set; }

        [Column(TypeName = "VARCHAR"), Required, MinLength(6)]
        public string Senha { get; set; }

        [Column(TypeName = "VARCHAR"), Required]
        public TipoEnum Tipo { get; set; }
        public ICollection<PacienteModel>? Pacientes { get; set; }
        public ICollection<ConsultaModel>? Consultas { get; set; }

    }
}