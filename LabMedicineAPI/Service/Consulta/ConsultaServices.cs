using AutoMapper;
using LabMedicineAPI.DTOs;
using LabMedicineAPI.DTOs.Consulta;
using LabMedicineAPI.Model;
using LabMedicineAPI.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

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

        public IEnumerable<ConsultaGetDTO> Get(int? pacienteId)
        {
            IEnumerable<ConsultaModel> consultas;

            if (pacienteId.HasValue)
            {
                consultas = _repository.GetAll().Where(c => c.PacienteId == pacienteId.Value);
            }
            else
            {
                consultas = _repository.GetAll();
            }

            var consultasDTO = _mapper.Map<IEnumerable<ConsultaGetDTO>>(consultas);
            return consultasDTO;

        }

        public ConsultaModel ConsultaCreateDTO(ConsultaCreateDTO consultaCreateDTO)
        {
            var consulta = _mapper.Map<ConsultaModel>(consultaCreateDTO);
            var consultaCreated = _repository.Create(consulta);
            var consultaCreatedDTO = _mapper.Map<ConsultaModel>(consultaCreated);
            return consultaCreatedDTO;

        }
        public ConsultaUpdateDTO ConsultaUpdate(int id, ConsultaUpdateDTO updateConsultaDTO)
        {
            if (_repository.GetById(id) == null)
                throw new Exception("Paciente não localizado em nossos registros");
            var consulta = _mapper.Map<ConsultaUpdateDTO, ConsultaModel>(updateConsultaDTO);
  
            _repository.Update(consulta);
            return updateConsultaDTO;
            //var consulta = _repository.GetById(id);
            //if (consulta == null)
            //{
            //    throw new Exception("Paciente não encontrado");
            //}
            //_mapper.Map(updateConsultaDTO, consulta);

            //var consultaUpdated = _repository.Update(consulta);
            //var consultaUpdateDTO = _mapper.Map<ConsultaModel>(consultaUpdated);
            //return consultaUpdateDTO;
        }

        public bool DeleteConsulta(int id)
        {
            return _repository.Delete(id);
        }

    }
}
