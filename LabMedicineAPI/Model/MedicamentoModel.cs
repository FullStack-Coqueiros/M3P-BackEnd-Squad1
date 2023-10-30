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
    [Table("Medicamento")]
    public class MedicamentoModel : BaseAtendimento
    {
        [Column(TypeName = "VARCHAR"), Required, MaxLength(100), MinLength(5)]
        public string NomeMedicamento { get; set; }

        [Required]
        public string TipoMedicamento { get; set; }

        [Required]
        public decimal Quantidade { get; set; }

        [Required]
        public string Unidade { get; set; }

        [Column(TypeName = "VARCHAR"), Required, MaxLength(1000), MinLength(10)]
        public string Observacoes { get; set; }

    }
}
