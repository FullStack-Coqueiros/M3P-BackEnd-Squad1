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
        readonly IRepository<EnderecoModel> _enderecoRepository;

        public PacienteServices(IRepository<PacienteModel> repository, IMapper mapper, IRepository<EnderecoModel> enderecoRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _enderecoRepository = enderecoRepository;
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

        public PacienteEnderecoCreateDTO CriarPacienteEndereco(PacienteEnderecoCreateDTO pacienteEnderecoCreateDTO)
        {
            var paciente = _mapper.Map<PacienteModel>(pacienteEnderecoCreateDTO.Paciente);
            var enderecoModel = _mapper.Map<EnderecoModel>(pacienteEnderecoCreateDTO.Endereco);

            paciente.Endereco = enderecoModel;

            _repository.Create(paciente);
            _enderecoRepository.Create(enderecoModel);

            return pacienteEnderecoCreateDTO;
            

            //PacienteModel paciente = _mapper.Map<PacienteEnderecoCreateModel>(pacienteCreateDTO);
            //_repository.Create(paciente);
            //PacienteModel pacienteCreate = _repository.GetAll()
            //    .Where(a => a.CPF == pacienteCreateDTO.CPF).FirstOrDefault();
            //PacienteGetDTO pacienteGet = _mapper.Map<PacienteGetDTO>(pacienteCreate);

            //return pacienteGet;

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
