using LabMedicineAPI.DTOs.Paciente;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.Service.Paciente
{
    public interface IPacienteServices
    {
        bool DeletePaciente(int id);
        IEnumerable<PacienteGetDTO> Get();
        PacienteGetDTO GetById(int id);
        PacienteGetDTO PacienteCreateDTO(PacienteCreateDTO pacienteCreateDTO);
        PacienteGetDTO PacienteUpdateDTO(int id, PacienteUpdateDTO updatePacienteDTO);
    }
}