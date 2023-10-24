using LabMedicineAPI.DTOs.Endereco;

namespace LabMedicineAPI.DTOs.Paciente
{
    public class PacienteEnderecoCreateDTO
    {
        public PacienteCreateDTO Paciente { get; set; }
        public EnderecoCreateDTO Endereco { get; set; }
    }
}
