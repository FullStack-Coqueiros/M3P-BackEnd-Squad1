using System.ComponentModel.DataAnnotations;

namespace LabMedicineAPI.DTOs.Endereco
{
    public class EnderecoUpdateDTO
    {

        [Required(ErrorMessage = "O preenchimento do campo CEP é obrigatório.")]
        public string CEP { get; set; }
        [Required(ErrorMessage = "O preenchimento do campo cidade é obrigatório.")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "O preenchimento do campo estado é obrigatório.")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "O preenchimento do campo logradouro é obrigatório.")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "O preenchimento do campo numero é obrigatório.")]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string PontoReferencia { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int PacienteId { get; set; }

    }
}