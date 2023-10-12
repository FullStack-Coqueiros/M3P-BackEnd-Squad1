using LabMedicineAPI.DTOs.Medicamento;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.Service.Medicamento
{
    public interface IMedicamentoServices
    {
        bool DeleteMedicamento(int id);
        IEnumerable<MedicamentoGetDTO> Get();
        MedicamentoGetDTO GetById(int id);
        MedicamentoModel medicamentoCreateDTO(MedicamentoCreateDTO medicamentoCreateDTO);
        MedicamentoModel MedicamentoUpdateDTO(int id, MedicamentoUpdateDTO updateMedicamentoDTO);
    }
}