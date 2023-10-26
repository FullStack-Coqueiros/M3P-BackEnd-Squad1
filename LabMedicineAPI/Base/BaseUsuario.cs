using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LabMedicineAPI.Enums;


namespace LabMedicineAPI.Base
{
    public class BaseUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR"), Required, MaxLength(64), MinLength(8)]
        public string NomeCompleto { get; set; }
        [Column(TypeName = "VARCHAR"), Required, MaxLength(100)]
        public GeneroEnum Genero { get; set; }
        [Column(TypeName = "VARCHAR"), Required, MaxLength(255)]
        public string CPF { get; set; }
        [Column(TypeName = "VARCHAR"), Required, MaxLength(100)]
        public string Email { get; set; }
        [Column(TypeName = "VARCHAR"), Required]
        public bool StatusSistema { get; set; } = true;
    }
}
