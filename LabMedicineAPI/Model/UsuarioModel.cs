using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LabMedicineAPI.Model.Enums;

namespace LabMedicineAPI.Model
{
    [Table("Usuario")]
    public class UsuarioModel
    {
       [Column(TypeName = "VARCHAR"), Required, MaxLength(64), MinLength(8)]
       public string NomeCompleto { get; set; }

       [Column(TypeName = "VARCHAR"), Required]
       public GeneroEnum Genero { get; set; }

       [Column(TypeName = "VARCHAR"), Required, MaxLength(14)]
       public string CPF { get; set; }

       [Column(TypeName = "VARCHAR"), Required, MaxLength(13)]
       public string Telefone { get; set; }

       //ver como fazer a validação do Email
       [Column(TypeName = "VARCHAR"), Required, MaxLength(100)]
       public string Email { get; set; }

       //ver como fazer a cripotografia
       [Column(TypeName = "VARCHAR"), Required, MinLength(6)]
       public string Senha { get; set; }

       [Column(TypeName = "VARCHAR"), Required]
       public TipoEnum Tipo { get; set; }

       [Column(TypeName = "VARCHAR"), Required]
       public bool StatusSistema { get; } = true;
    }
}