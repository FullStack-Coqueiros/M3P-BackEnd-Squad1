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
        [Column(TypeName = "VARCHAR"), Required, MaxLength(255)]
        public string Telefone { get; set; }

        [Column(TypeName = "VARCHAR"), Required, MinLength(6), MaxLength(255)]
        public string Senha { get; set; }

        [Column(TypeName = "VARCHAR"), Required, MaxLength(255)]
        public string Tipo { get; set; }
        
        public virtual ICollection<ConsultaModel>? Consultas { get; set; }

    }
}