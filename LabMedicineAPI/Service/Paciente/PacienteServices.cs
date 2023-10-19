using AutoMapper;
using LabMedicineAPI.DTOs.Paciente;
using LabMedicineAPI.Model;
using LabMedicineAPI.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace LabMedicineAPI.Service.Paciente
{
    public class PacienteServices : IPacienteServices
    {
        readonly IRepository<PacienteModel> _repository;
        readonly IMapper _mapper;

        public PacienteServices(IRepository<PacienteModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<PacienteGetDTO> Get()
        {
            IEnumerable<PacienteModel> pacientes = _repository.GetAll();
            IEnumerable<PacienteGetDTO>pacientesDTO = _mapper.Map<IEnumerable<PacienteGetDTO>>(pacientes);
            return pacientesDTO;
        }

        public PacienteGetDTO GetById(int id)
        {
            var paciente = _repository.GetById(id);
            var pacienteDTO = _mapper.Map<PacienteGetDTO>(paciente);
            return pacienteDTO;
        }

        public PacienteGetDTO PacienteCreateDTO(PacienteCreateDTO pacienteCreateDTO)
        {
            PacienteModel paciente = _mapper.Map<PacienteModel>(pacienteCreateDTO);
            _repository.Create(paciente);
            PacienteModel pacienteCreate = _repository.GetAll()
                .Where(a => a.CPF == pacienteCreateDTO.CPF).FirstOrDefault();
            PacienteGetDTO pacienteGet = _mapper.Map<PacienteGetDTO>(pacienteCreate);
 
            return pacienteGet;

        }
        public PacienteGetDTO PacienteUpdateDTO(int id, PacienteUpdateDTO updatePacienteDTO)
        {
            PacienteModel paciente = _repository.GetById(id);
            paciente = _mapper.Map(updatePacienteDTO, paciente);

            _repository.Update(paciente);
            PacienteModel pacienteUpdated = _repository.GetById(id);
            PacienteGetDTO pacienteGet = _mapper.Map<PacienteGetDTO>(pacienteUpdated);
            return pacienteGet;
        }

        public bool DeletePaciente(int id)
        {
            return _repository.Delete(id);
        }

    }
}
