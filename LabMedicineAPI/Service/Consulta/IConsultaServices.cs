using LabMedicineAPI.DTOs;
using LabMedicineAPI.DTOs.Consulta;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.Service.Consulta
{
    public interface IConsultaServices
    {
        ConsultaModel ConsultaCreateDTO(ConsultaCreateDTO consultaCreateDTO);
        ConsultaUpdateDTO ConsultaUpdate(int id, ConsultaUpdateDTO updateConsultaDTO);
        bool DeleteConsulta(int id);
        IEnumerable<ConsultaGetDTO> Get(int? pacienteId);
    }
}