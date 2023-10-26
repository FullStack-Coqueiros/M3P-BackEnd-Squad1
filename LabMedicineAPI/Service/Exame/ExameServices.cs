using AutoMapper;
using LabMedicineAPI.DTOs;
using LabMedicineAPI.DTOs.Consulta;
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

        public IEnumerable<ExameGetDTO> Get(int? pacienteId)
        {
            IEnumerable<ExameModel> exames;

            if (pacienteId.HasValue)
            {
                exames = _repository.GetAll().Where(c => c.PacienteId == pacienteId.Value);
            }
            else
            {
                exames = _repository.GetAll();
            }

            var examesDTO = _mapper.Map<IEnumerable<ExameGetDTO>>(exames);
            return examesDTO;

        }
        public ExameGetDTO GetById(int id)
        {
            ExameModel exame = _repository.GetById(id);
            ExameGetDTO exameDTO = _mapper.Map<ExameGetDTO>(exame);
            return exameDTO;
        }
        public ExameModel ExameUpdate (int id, ExameUpdateDTO dTO)
        {
            var exame = _repository.GetById(id);
            if(exame == null)
            {
                throw new Exception("O exame com o ID informado não foi encontrado em nossos registros");
            }
            _mapper.Map(dTO, exame);
            _repository.Update(exame);
            return exame;
        }
        public ExameModel ExameCreateDTO(ExameCreateDTO exameCreateDTO)
        {
           
            var exame = _mapper.Map<ExameModel>(exameCreateDTO);
            var exameCreated = _repository.Create(exame);
            var exameCreatedDTO = _mapper.Map<ExameModel>(exameCreated);
            return exameCreatedDTO;

        }

        public bool DeleteExame(int id)
        {
            return _repository.Delete(id);
        }

    }
}
