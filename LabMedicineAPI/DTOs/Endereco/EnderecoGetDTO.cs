namespace LabMedicineAPI.DTOs.Endereco
{
    public class EnderecoGetDTO
    {
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string PontoReferencia { get; set; }
        public int UsuarioId { get; set; }
        public int PacienteId { get; set; }

    }
}