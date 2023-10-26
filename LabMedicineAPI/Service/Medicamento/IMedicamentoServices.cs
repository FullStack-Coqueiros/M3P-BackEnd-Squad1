using LabMedicineAPI.DTOs.Medicamento;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.Service.Medicamento
{
    public interface IMedicamentoServices
    {
        bool DeleteMedicamento(int id);
       // IEnumerable<MedicamentoGetDTO> Get();
        IEnumerable<MedicamentoGetDTO> Get(int? pacienteId);
        MedicamentoGetDTO GetById(int id);
        MedicamentoModel MedicamentoCreateDTO(MedicamentoCreateDTO medicamentoCreateDTO);
        MedicamentoModel MedicamentoUpdateDTO(int id, MedicamentoUpdateDTO updateMedicamentoDTO);
    }
}