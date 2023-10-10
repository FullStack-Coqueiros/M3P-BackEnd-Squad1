using AutoMapper;
using LabMedicineAPI.DTOs;
using LabMedicineAPI.Interfaces;
using LabMedicineAPI.Model;
using LabMedicineAPI.Repositories;
using static LabMedicineAPI.Services.Auth.UserServices;

namespace LabMedicineAPI.Services.Auth
{


    public class UserServices:IUserServices
    {
        readonly IRepository<UsuarioModel> _repository;
        readonly IMapper _mapper;

        public UserServices(IRepository<UsuarioModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public UsuarioModel Atualizar(int id,UsuarioUpdateDTO UpdateDTO)
        {
            var usuario = _repository.GetById(id);
            if(usuario == null)
            {
                throw new Exception("Usuario não encontrado");
            }
            _mapper.Map(UpdateDTO, usuario);
            var usuarioUpdated = _repository.Update(usuario);
            var usuarioUpdateDTO = _mapper.Map<UsuarioModel>(usuarioUpdated);
            return usuarioUpdateDTO;
            
        }

        public UsuarioModel Criar(UsuarioCreateDTO createDTO)
        {
            var usuario = _mapper.Map<UsuarioModel>(createDTO);
            var usuarioCreated = _repository.Create(usuario);
            var usuarioCreatedDTO = _mapper.Map<UsuarioModel>(usuarioCreated);
            return usuarioCreatedDTO;
         
        }
        public bool Deletar(int id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<UsuarioGetDTO> Obter()
        {
            var usuarios = _repository.GetAll();
            var usuariosDTO = _mapper.Map<IEnumerable<UsuarioGetDTO>>(usuarios);
            return usuariosDTO;
        }

        public UsuarioModel ObterPorLogin(string login)
        {
            
            return new UsuarioModel()
            {
                NomeCompleto = "Teste Nome",
                Email = "teste@teste",
                Senha = "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=",
                Tipo = Enums.TipoEnum.Medico,
                StatusSistema = true
            };
        }
    }

}
