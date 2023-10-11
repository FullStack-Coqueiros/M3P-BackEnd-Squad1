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
    [Table("Dieta")]
    public class DietaModel : BaseAtendimento
    {
        [Column(TypeName = "VARCHAR"), Required, MaxLength(100), MinLength(5)]
        public string NomeDieta { get; set; }

        public string? DescricaoDieta { get; set; }

        [Required]
        public TipoDietaEnum TipoDieta { get; set; }

        public string? DescricaoDetalhada { get; set; }


    }



}