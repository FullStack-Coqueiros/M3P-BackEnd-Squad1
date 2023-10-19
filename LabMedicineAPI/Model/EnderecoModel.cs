using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LabMedicineAPI.Model
{
    [Table("Endereco")]
    public class EnderecoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR"), Required]
        public string CEP { get; set; }
        [Column(TypeName = "VARCHAR"), Required]
        public string Cidade { get; set; }
        [Column(TypeName = "VARCHAR"), Required]
        public string Estado { get; set; }
        [Column(TypeName = "VARCHAR"), Required]
        public string Logradouro { get; set; }
        [Column(TypeName = "VARCHAR"), Required]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string PontoReferencia { get; set; }

        [Required]
        [ForeignKey("PacienteModel")]
        public int PacienteId { get; set; }
    }
}