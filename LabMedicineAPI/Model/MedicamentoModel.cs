using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LabMedicineAPI.Model.Enums;

namespace LabMedicineAPI.Model
{
    [Table("Medicamento")]
    public class MedicamentoModel
    {
        [Column(TypeName = "VARCHAR"), Required, MaxLength(100), MinLength(5)]
        public string NomeMedicamento { get; set; }

        //verificar se o tipo de dado dessa prop esta correto
        [Required]
        public DateTime Data { get; set; }

        //verificar se o tipo de dado dessa prop esta correto
        [Required]
        public DateTime Horario { get; set; }

        [Required]
        public TipoMedicamentoEnum TipoMedicamento { get; set; }

        //verificar o tipo de dado para duas casas depois da virgula
        public int Quantidade { get; set; }

        //ajustar no Enum a %
        [Required]
        public UnidadeEnum Unidade { get; set; }

        public bool StatusSistema { get; set; }

        //ver como inserir a prop PacienteId e UsuarioId
    }
}