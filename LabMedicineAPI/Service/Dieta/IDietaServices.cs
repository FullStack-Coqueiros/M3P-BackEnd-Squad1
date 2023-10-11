using LabMedicineAPI.DTOs.Dieta;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.Service.Dieta
{
    public interface IDietaServices
    {
        bool DeleteDieta(int id);
        DietaModel DietaCreateDTO(DietaCreateDTO dietaCreateDTO);
        DietaModel DietaUpdateDTO(int id, DietaUpdateDTO updateDietaDTO);
        IEnumerable<DietaGetDTO> Get();
        DietaGetDTO GetById(int id);
    }
}