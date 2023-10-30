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
    [Table("Exercicio")]

    public class ExercicioModel : BaseAtendimento
    {
        [Column(TypeName = "VARCHAR"), Required, MaxLength(100), MinLength(5)]
        public string NomeSerieExerc { get; set; }

        [Required]
        public string TipoExerc { get; set; }

        [Required]
        public decimal QuantidadeSemana { get; set; }

        [Column(TypeName = "VARCHAR"), Required, MaxLength(1000), MinLength(10)]
        public string DescricaoExerc { get; set; }
    }     

}