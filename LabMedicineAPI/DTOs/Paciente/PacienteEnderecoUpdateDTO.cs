using LabMedicineAPI.DTOs.Endereco;

namespace LabMedicineAPI.DTOs.Paciente
{
    public class PacienteEnderecoUpdateDTO
    {
        public PacienteUpdateDTO Paciente { get; set; }
        public EnderecoUpdateDTO Endereco { get; set; }
    }
}
