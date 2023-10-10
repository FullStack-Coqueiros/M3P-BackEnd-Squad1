using LabMedicineAPI.DTOs.Paciente;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.Service
{
    public interface IPacienteServices
    {
        bool DeletePaciente(int id);
        IEnumerable<PacienteGetDTO> Get();
        PacienteGetDTO GetById(int id);
        PacienteModel PacienteCreateDTO(PacienteCreateDTO pacienteCreateDTO);
        PacienteModel PacienteUpdateDTO(int id, PacienteUpdateDTO updatePacienteDTO);
    }
}