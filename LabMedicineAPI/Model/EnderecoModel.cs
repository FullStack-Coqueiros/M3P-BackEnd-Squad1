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
        public int Id { get; }
        [Column(TypeName = "VARCHAR"),MaxLength(255), Required]
        public string CEP { get; set; }
        [Column(TypeName = "VARCHAR"), MaxLength(255), Required]
        public string Cidade { get; set; }
        [Column(TypeName = "VARCHAR"), MaxLength(255), Required]
        public string Estado { get; set; }
        [Column(TypeName = "VARCHAR"), MaxLength(255), Required]
        public string Logradouro { get; set; }
        [Column(TypeName = "VARCHAR"), MaxLength(255), Required]
        public string Numero { get; set; }
        [Column(TypeName = "VARCHAR"), MaxLength(255)]
        public string Complemento { get; set; }
        [Column(TypeName = "VARCHAR"), MaxLength(255)]
        public string Bairro { get; set; }
        [Column(TypeName = "VARCHAR"), MaxLength(255)]
        public string PontoReferencia { get; set; }

        [Required]
        [ForeignKey("PacienteModel")]
        public int PacienteId { get; set; }
        public PacienteModel Paciente { get; set; }
    }
}