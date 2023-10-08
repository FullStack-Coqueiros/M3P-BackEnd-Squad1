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
        public int EnderecoId { get; set; }
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
        [Column(TypeName = "VARCHAR"), Required]
        public string Complemento { get; set; }
        [Column(TypeName = "VARCHAR"), Required]
        public string Bairro { get; set; }
        [Column(TypeName = "VARCHAR"), Required]
        public string PontoReferencia { get; set; }

        [Required]
        [ForeignKey("Usuario Model")]
        public int UsuarioId { get; set; }
        [Required]
        public UsuarioModel Usuario { get; set; }

        [Required]
        [ForeignKey("Paciente Model")]
        public int PacienteId { get; set; }

        [Required]
        public PacienteModel Paciente { get; set; }


    }
}