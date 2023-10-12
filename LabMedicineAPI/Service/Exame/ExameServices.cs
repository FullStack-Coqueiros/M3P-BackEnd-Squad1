using AutoMapper;
using LabMedicineAPI.DTOs;
using LabMedicineAPI.DTOs.Exame;
using LabMedicineAPI.DTOs.Usuario;
using LabMedicineAPI.Model;
using LabMedicineAPI.Repositories;
using LabMedicineAPI.Service.Usuario;

namespace LabMedicineAPI.Service.Exame
{
    public class ExameServices : IExameServices
    {

        readonly IRepository<ExameModel> _repository;
        readonly IMapper _mapper;

        public ExameServices(IRepository<ExameModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<ExameGetDTO> Get()
        {
            var exames = _repository.GetAll();
            var examesDTO = _mapper.Map<IEnumerable<ExameGetDTO>>(exames);
            return examesDTO;
        }

        public ExameGetDTO GetById(int id)
        {
            var exame = _repository.GetById(id);
            var exameDTO = _mapper.Map<ExameGetDTO>(exame);
            return exameDTO;
        }

        public ExameModel ExameCreateDTO(ExameCreateDTO exameCreateDTO)
        {
            var exame = _mapper.Map<ExameModel>(exameCreateDTO);
            var exameCreated = _repository.Create(exame);
            var exameCreatedDTO = _mapper.Map<ExameModel>(exameCreated);
            return exameCreatedDTO;

        }
        public ExameModel exameUpdateDTO(int id, ExameUpdateDTO updateExameDTO)
        {
            var exame = _repository.GetById(id);
            if (exame == null)
            {
                throw new Exception("Exame com id indicado  não encontrado");
            }
            _mapper.Map(updateExameDTO, exame);

            var exameUpdated = _repository.Update(exame);
            var exameUpdateDTO = _mapper.Map<ExameModel>(exameUpdated);
            return exameUpdateDTO;
        }

        public bool DeleteExame(int id)
        {
            return _repository.Delete(id);
        }



    }
}
