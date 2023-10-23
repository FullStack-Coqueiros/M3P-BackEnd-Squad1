using AutoMapper;
using LabMedicineAPI.DTOs.Endereco;
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
            IEnumerable<PacienteGetDTO> pacientesDTO = _mapper.Map<IEnumerable<PacienteGetDTO>>(pacientes);
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

            var conflitoCPF = _repository.GetAll().Where(x => x.CPF == paciente.CPF).FirstOrDefault();
            if (conflitoCPF != null)
            {
                throw new Exception("Já existe um paciente com o CPF informado cadastrado no sistema.");
            }

            var conflitoEmail = _repository.GetAll().Where(x => x.Email == paciente.Email).FirstOrDefault();
            if (conflitoEmail != null)
            {
                throw new Exception("Já existe um paciente com o email informado cadastrado no sistema.");
            }

            _repository.Create(paciente);

            paciente.Endereco = enderecoModel;
            _enderecoRepository.Create(enderecoModel);

            return pacienteEnderecoCreateDTO;
        }

        public PacienteEnderecoUpdateDTO PacienteEnderecoUpdate(int id, PacienteEnderecoUpdateDTO pacienteEnderecoUpdateDTO)
        {
            PacienteModel paciente = _repository.GetById(id);

            if (paciente != null)
            {
                _mapper.Map(pacienteEnderecoUpdateDTO.Paciente, paciente); // Mapeia os dados do paciente do DTO para o modelo do paciente.

                if (paciente.Endereco == null)
                {
                    EnderecoModel novoEndereco = _mapper.Map<EnderecoModel>(pacienteEnderecoUpdateDTO.Endereco);
                    var endereco = _enderecoRepository.GetByPacienteId(paciente.Id);
                    if (endereco != null)
                    {
                        _mapper.Map(pacienteEnderecoUpdateDTO.Endereco, endereco);
                        _enderecoRepository.Update(endereco);
                    }
                    else
                    {

                        paciente.Endereco = novoEndereco;
                        _enderecoRepository.Create(paciente.Endereco);

                    }

                }

                return pacienteEnderecoUpdateDTO;
            }
            else
            {

                throw new Exception("Não foi localizado o registro com o id indicado");
            }
        }

        public bool DeletePaciente(int id)
        {
            var paciente = _repository.GetById(id);

            if (paciente != null)
            {
                var impedimento = VerificarImpedimentosDelecao(paciente);
                if (paciente.Endereco != null)
                {
                    _enderecoRepository.Delete(paciente.Endereco.Id);
                }

                return _repository.Delete(id);
            }

            return false;
        }
        private string VerificarImpedimentosDelecao(PacienteModel paciente)
        {
            if (paciente.Consultas != null && paciente.Consultas.Count > 0)
            {
                return "Não é possível excluir o paciente, pois ele tem consultas vinculadas.";
            }

            if (paciente.Dietas != null && paciente.Dietas.Count > 0)
            {
                return "Não é possível excluir o paciente, pois ele tem dietas vinculadas.";
            }

            if (paciente.Exames != null && paciente.Exames.Count > 0)
            {
                return "Não é possível excluir o paciente, pois ele tem exames vinculados.";
            }

            if (paciente.Exercicios != null && paciente.Exercicios.Count > 0)
            {
                return "Não é possível excluir o paciente, pois ele tem exercícios vinculados.";
            }

            if (paciente.Medicamentos != null && paciente.Medicamentos.Count > 0)
            {
                return "Não é possível excluir o paciente, pois ele tem medicamentos vinculados.";
            }

            return null;
        }

    }

}
