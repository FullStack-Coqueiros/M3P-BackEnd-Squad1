using AutoMapper;
using LabMedicineAPI.DTOs.Dieta;
using LabMedicineAPI.DTOs.Exercicio;
using LabMedicineAPI.DTOs.Usuario;
using LabMedicineAPI.Model;
using LabMedicineAPI.Repositories;

namespace LabMedicineAPI.Service.Dieta
{
    public class DietaServices : IDietaServices
    {
        readonly IRepository<DietaModel> _repository;
        readonly IMapper _mapper;

        public DietaServices(IRepository<DietaModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IEnumerable<DietaGetDTO> Get(int? pacienteId)
        {
            IEnumerable<DietaModel> dietas;

            if (pacienteId.HasValue)
            {
                dietas = _repository.GetAll().Where(c => c.PacienteId == pacienteId.Value);
            }
            else
            {
                dietas =_repository.GetAll();
            }

            var dietasDTO = _mapper.Map<IEnumerable<DietaGetDTO>>(dietas);
            return dietasDTO;
        }


        public DietaGetDTO GetById(int id)
        {
            var dieta = _repository.GetById(id);
            var dietaDTO = _mapper.Map<DietaGetDTO>(dieta);
            return dietaDTO;
        }

        public DietaModel DietaCreateDTO(DietaCreateDTO dietaCreateDTO)
        {
            var dieta = _mapper.Map<DietaModel>(dietaCreateDTO);
            var dietaCreated = _repository.Create(dieta);
            var dietaCreatedDTO = _mapper.Map<DietaModel>(dietaCreated);
            return dietaCreatedDTO;

        }
        public DietaModel DietaUpdateDTO(int id, DietaUpdateDTO updateDietaDTO)
        {
            var dieta = _repository.GetById(id);
            if (dieta == null)
            {
                throw new Exception("Dieta com id indicado não foi encontrado");
            }
            _mapper.Map(updateDietaDTO, dieta);

            var dietaUpdated = _repository.Update(dieta);
            var dietaUpdateDTO = _mapper.Map<DietaModel>(dietaUpdated);
            return dietaUpdateDTO;
        }

        public bool DeleteDieta(int id)
        {
            return _repository.Delete(id);
        }
    }
}
