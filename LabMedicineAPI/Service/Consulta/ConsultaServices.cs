using AutoMapper;
using LabMedicineAPI.DTOs;
using LabMedicineAPI.DTOs.Consulta;
using LabMedicineAPI.Model;
using LabMedicineAPI.Repositories;


namespace LabMedicineAPI.Service.Consulta
{
    public class ConsultaServices : IConsultaServices
    {
        readonly IRepository<ConsultaModel> _repository;
        readonly IMapper _mapper;

        public ConsultaServices(IRepository<ConsultaModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<ConsultaGetDTO> Get()
        {
            var consultas = _repository.GetAll();
            var consultasDTO = _mapper.Map<IEnumerable<ConsultaGetDTO>>(consultas);
            return consultasDTO;
        }

        public ConsultaGetDTO GetById(int id)
        {
            var consulta = _repository.GetById(id);
            var consultaDTO = _mapper.Map<ConsultaGetDTO>(consulta);
            return consultaDTO;
        }

        public ConsultaModel ConsultaCreateDTO(ConsultaCreateDTO consultaCreateDTO)
        {
            var consulta = _mapper.Map<ConsultaModel>(consultaCreateDTO);
            var consultaCreated = _repository.Create(consulta);
            var consultaCreatedDTO = _mapper.Map<ConsultaModel>(consultaCreated);
            return consultaCreatedDTO;

        }
        public ConsultaModel ConsultaUpdateDTO(int id, ConsultaUpdateDTO updateConsultaDTO)
        {
            var consulta = _repository.GetById(id);
            if (consulta == null)
            {
                throw new Exception("Paciente não encontrado");
            }
            _mapper.Map(updateConsultaDTO, consulta);

            var consultaUpdated = _repository.Update(consulta);
            var consultaUpdateDTO = _mapper.Map<ConsultaModel>(consultaUpdated);
            return consultaUpdateDTO;
        }

        public bool DeleteConsulta(int id)
        {
            return _repository.Delete(id);
        }

    }
}
