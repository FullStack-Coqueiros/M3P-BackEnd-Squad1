using AutoMapper;
using LabMedicineAPI.DTOs.Login;
using LabMedicineAPI.DTOs.Usuario;
using LabMedicineAPI.Infra;
using LabMedicineAPI.Interfaces;
using LabMedicineAPI.Model;
using LabMedicineAPI.Repositories;
using System.Linq.Expressions;
using static LabMedicineAPI.Service.Auth.UserServices;

namespace LabMedicineAPI.Service.Auth
{


    public class UserServices : IUserServices
    {
        readonly IRepository<UsuarioModel> _repository;
        readonly IMapper _mapper;


        public UserServices(IRepository<UsuarioModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public UsuarioModel Atualizar(int id, UsuarioUpdateDTO UpdateDTO)
        {
            var usuario = _repository.GetById(id);
            if (usuario == null)
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

        public UsuarioModel ObterPorLogin(LoginDTO login)
        {
            Expression<Func<UsuarioModel, bool>> user = u => u.Email == login.Email;

            return _repository.GetByUser(user);

        }
    }

}
//public UsuarioModel ObterPorLogin(string email, string senha)
//{
//    var criteria = (Expression<Func<UsuarioModel, bool>>)(u => u.Email == email && u.Senha == senha);
//    return _repository.GetByUser(criteria);

//}

//return new UsuarioModel()
//{
//    NomeCompleto = "Teste Nome",
//    Email = "teste@teste",
//    Senha = "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=",
//    Tipo = Enums.TipoEnum.Medico,
//    StatusSistema = true
//};