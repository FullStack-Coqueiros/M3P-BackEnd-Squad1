using LabMedicineAPI.DTOs.Paciente;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.Service.Paciente
{
    public interface IPacienteServices
    {
        PacienteEnderecoCreateDTO CriarPacienteEndereco(PacienteEnderecoCreateDTO pacienteEnderecoCreateDTO);
        bool DeletePaciente(int id);
        IEnumerable<PacienteGetDTO> Get();
        PacienteGetDTO GetById(int id);
        PacienteEnderecoUpdateDTO PacienteEnderecoUpdate(int id, PacienteEnderecoUpdateDTO pacienteEnderecoUpdateDTO);    
    }
}