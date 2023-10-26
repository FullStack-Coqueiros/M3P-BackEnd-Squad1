using LabMedicineAPI.DTOs;
using LabMedicineAPI.DTOs.Exame;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.Service.Exame
{
    public interface IExameServices
    {
        IEnumerable<ExameGetDTO> Get(int? pacienteId);
        ExameGetDTO GetById(int id);
        ExameModel ExameCreateDTO(ExameCreateDTO exameCreateDTO);
        bool DeleteExame(int id);
       // ExameGetDTO ExameUpdateDTO(ExameUpdateDTO updateExameDTO);
        ExameModel ExameUpdate(int id, ExameUpdateDTO dTO);
    }
}