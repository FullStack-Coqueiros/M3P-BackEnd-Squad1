using LabMedicineAPI.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LabMedicineAPI.Model
{
    [Table("Exame")]
    public class ExameModel:BaseAtendimento
    {
        [Column(TypeName = "VARCHAR"), Required, MaxLength(64), MinLength(8)]
        public string NomeExame { get; set; }
              
        [Column(TypeName = "VARCHAR"), Required, MaxLength(32), MinLength(4)]
        public string TipoExame { get; set; }

        [Column(TypeName = "VARCHAR"), Required, MaxLength(32), MinLength(4)]
        public string Laboratorio { get; set; }

        public string Url { get; set; }

        [Column(TypeName = "VARCHAR"), Required, MaxLength(1024), MinLength(16)]
        public string Resultados { get; set; }

    }
}