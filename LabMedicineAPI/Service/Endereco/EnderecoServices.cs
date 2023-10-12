using AutoMapper;
using LabMedicineAPI.DTOs.Endereco;
using LabMedicineAPI.DTOs.Paciente;
using LabMedicineAPI.Model;
using LabMedicineAPI.Repositories;
using LabMedicineAPI.Service.Paciente;

namespace LabMedicineAPI.Service.Endereco
{
    public class EnderecoServices : IEnderecoServices
    {
        readonly IRepository<EnderecoModel> _repository;
        readonly IMapper _mapper;

        public EnderecoServices(IRepository<EnderecoModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<EnderecoGetDTO> Get()
        {
            var enderecos = _repository.GetAll();
            var enderecosDTO = _mapper.Map<IEnumerable<EnderecoGetDTO>>(enderecos);
            return enderecosDTO;
        }

        public EnderecoGetDTO GetById(int id)
        {
            var endereco = _repository.GetById(id);
            var enderecoDTO = _mapper.Map<EnderecoGetDTO>(endereco);
            return enderecoDTO;
        }

        public EnderecoModel EnderecoCreateDTO(EnderecoCreateDTO enderecoCreateDTO)
        {
            var endereco = _mapper.Map<EnderecoModel>(enderecoCreateDTO);
            var enderecoCreated = _repository.Create(endereco);
            var enderecoCreatedDTO = _mapper.Map<EnderecoModel>(enderecoCreated);
            return enderecoCreatedDTO;

        }
        public EnderecoModel EnderecoUpdateDTO(int id, EnderecoUpdateDTO updateEnderecoDTO)
        {
            var endereco = _repository.GetById(id);
            if (endereco == null)
            {
                throw new Exception("Endereço com id informado não encontrado");
            }
            _mapper.Map(updateEnderecoDTO, endereco);

            var enderecoUpdated = _repository.Update(endereco);
            var enderecoUpdateDTO = _mapper.Map<EnderecoModel>(enderecoUpdated);
            return enderecoUpdateDTO;
        }

        public bool DeleteEndereco(int id)
        {
            return _repository.Delete(id);
        }

    }
}
