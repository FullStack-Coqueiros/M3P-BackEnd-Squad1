using LabMedicineAPI.DTOs;
using LabMedicineAPI.DTOs.Consulta;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.Service.Consulta
{
    public interface IConsultaServices
    {
        ConsultaModel ConsultaCreateDTO(ConsultaCreateDTO consultaCreateDTO);
        ConsultaModel ConsultaUpdateDTO(int id, ConsultaUpdateDTO updateConsultaDTO);
        bool DeleteConsulta(int id);
        IEnumerable<ConsultaGetDTO> Get();
        ConsultaGetDTO GetById(int id);
    }
}