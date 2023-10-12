using LabMedicineAPI.DTOs.Exercicio;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.Service.Exercicio
{
    public interface IExercicioServices
    {
        bool DeleteExercicio(int id);
        ExercicioModel ExercicioCreateDTO(ExercicioCreateDTO exercicioCreateDTO);
        ExercicioModel ExercicioUpdateDTO(int id, ExercicioUpdateDTO updateExercicioDTO);
        IEnumerable<ExercicioGetDTO> Get();
        ExercicioGetDTO GetById(int id);
    }
}