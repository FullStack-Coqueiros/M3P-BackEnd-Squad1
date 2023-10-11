using AutoMapper;
using LabMedicineAPI.DTOs.Exercicio;
using LabMedicineAPI.DTOs.Usuario;
using LabMedicineAPI.Model;
using LabMedicineAPI.Repositories;

namespace LabMedicineAPI.Service.Exercicio
{
    public class ExercicioServices : IExercicioServices
    {
        readonly IRepository<ExercicioModel> _repository;
        readonly IMapper _mapper;

        public ExercicioServices(IRepository<ExercicioModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<ExercicioGetDTO> Get()
        {
            var exercicios = _repository.GetAll();
            var exerciciosDTO = _mapper.Map<IEnumerable<ExercicioGetDTO>>(exercicios);
            return exerciciosDTO;
        }

        public ExercicioGetDTO GetById(int id)
        {
            var exercicio = _repository.GetById(id);
            var exercicioDTO = _mapper.Map<ExercicioGetDTO>(exercicio);
            return exercicioDTO;
        }

        public ExercicioModel ExercicioCreateDTO(ExercicioCreateDTO exercicioCreateDTO)
        {
            var exercicio = _mapper.Map<ExercicioModel>(exercicioCreateDTO);
            var exercicioCreated = _repository.Create(exercicio);
            var exercicioCreatedDTO = _mapper.Map<ExercicioModel>(exercicioCreated);
            return exercicioCreatedDTO;

        }
        public ExercicioModel ExercicioUpdateDTO(int id, ExercicioUpdateDTO updateExercicioDTO)
        {
            var exercicio = _repository.GetById(id);
            if (exercicio == null)
            {
                throw new Exception("Exercício com id indicado não foi encontrado");
            }
            _mapper.Map(updateExercicioDTO, exercicio);

            var exercicioUpdated = _repository.Update(exercicio);
            var exercicioUpdateDTO = _mapper.Map<ExercicioModel>(exercicioUpdated);
            return exercicioUpdateDTO;
        }

        public bool DeleteExercicio(int id)
        {
            return _repository.Delete(id);
        }
    }
}
