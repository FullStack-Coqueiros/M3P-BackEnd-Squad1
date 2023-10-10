using AutoMapper;
using LabMedicineAPI.DTOs.Paciente;
using LabMedicineAPI.Model;
using LabMedicineAPI.Repositories;

namespace LabMedicineAPI.Service
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
            var pacientes = _repository.GetAll();
            var pacientesDTO = _mapper.Map<IEnumerable<PacienteGetDTO>>(pacientes);
            return pacientesDTO;
        }

        public PacienteGetDTO GetById(int id)
        {
            var paciente = _repository.GetById(id);
            var pacienteDTO = _mapper.Map<PacienteGetDTO>(paciente);
            return pacienteDTO;
        }

        public PacienteModel PacienteCreateDTO(PacienteCreateDTO pacienteCreateDTO)
        {
            var paciente = _mapper.Map<PacienteModel>(pacienteCreateDTO);
            var pacienteCreated = _repository.Create(paciente);
            var pacienteCreatedDTO = _mapper.Map<PacienteModel>(pacienteCreated);
            return pacienteCreatedDTO;

        }
        public PacienteModel PacienteUpdateDTO(int id, PacienteUpdateDTO updatePacienteDTO)
        {
            var paciente = _repository.GetById(id);
            if (paciente == null)
            {
                throw new Exception("Paciente não encontrado");
            }
            _mapper.Map(updatePacienteDTO, paciente);

            var pacienteUpdated = _repository.Update(paciente);
            var pacienteUpdateDTO = _mapper.Map<PacienteModel>(pacienteUpdated);
            return pacienteUpdateDTO;
        }

        public bool DeletePaciente(int id)
        {
            return _repository.Delete(id);
        }

    }
}
