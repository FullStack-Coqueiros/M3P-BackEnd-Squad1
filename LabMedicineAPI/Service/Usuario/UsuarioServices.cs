using AutoMapper;
using LabMedicineAPI.DTOs.Paciente;
using LabMedicineAPI.DTOs.Usuario;
using LabMedicineAPI.Enums;
using LabMedicineAPI.Model;
using LabMedicineAPI.Repositories;
using LabMedicineAPI.Service.Paciente;
using Microsoft.IdentityModel.Tokens;

namespace LabMedicineAPI.Service.Usuario
{

    public class UsuarioServices : IUsuarioServices
    {
        readonly IRepository<UsuarioModel> _repository;
        readonly IMapper _mapper;

        public UsuarioServices(IRepository<UsuarioModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public UsuarioGetDTO GetByEmail(string email)
        {
            IEnumerable<UsuarioModel> usuarios = _repository.GetAll().Where(x => x.Email == email);
            if (usuarios.IsNullOrEmpty())
            {
                return null;
            }
            else
            {
                UsuarioModel usuario = usuarios.First();
                return _mapper.Map<UsuarioGetDTO>(usuario);
            }
        }
        public IEnumerable<UsuarioGetDTO> Get()
        {
            IEnumerable<UsuarioModel> usuarios = _repository.GetAll();
            IEnumerable<UsuarioGetDTO> usuariosDTO = _mapper.Map<IEnumerable<UsuarioGetDTO>>(usuarios);
            return usuariosDTO;
        }

        public UsuarioGetDTO GetById(int id)
        {
            UsuarioModel usuario = _repository.GetById(id);
            UsuarioGetDTO usuarioDTO = _mapper.Map<UsuarioGetDTO>(usuario);
            return usuarioDTO;
        }

        public UsuarioGetDTO CreateUsuario(UsuarioCreateDTO usuario)
        {
            UsuarioModel usuarioModel = _mapper.Map<UsuarioModel>(usuario);
            //usuarioModel.Genero = Enum.GetName(typeof(GeneroEnum), usuario.Genero.GetHashCode());
            //usuarioModel.Tipo = Enum.GetName(typeof(TipoEnum), usuario.Tipo.GetHashCode());
            _repository.Create(usuarioModel);
            UsuarioModel usuarioModelComId = _repository.GetAll().Where(x => x.Email == usuarioModel.Email).FirstOrDefault();
            UsuarioGetDTO usuarioGet = _mapper.Map<UsuarioGetDTO>(usuarioModelComId);
            return usuarioGet;
        }
        public UsuarioGetDTO UsuarioUpdateDTO(int id ,UsuarioUpdateDTO updateUsuarioDTO)
        {
            UsuarioModel model = _repository.GetById(id);
            model = _mapper.Map(updateUsuarioDTO, model);
            if (updateUsuarioDTO.StatusSistema == false)
                DesativarRecursosRelacionados(model);
            _repository.Update(model);
            UsuarioModel usuarioUpdated = _repository.GetById(id);
            UsuarioGetDTO usuarioGet = _mapper.Map<UsuarioGetDTO>(usuarioUpdated);
            return usuarioGet;
         
        }

        public bool DeleteUsuario(int id, int userId)
        {
            var usuario = _repository.GetById(id);
            if(usuario != null && usuario.Id != userId)
            {
                var impedimentos = VerificarImpedimentosDelecao(usuario);
                if (string.IsNullOrEmpty(impedimentos))
                {
                    return _repository.Delete(id);
                }
            }
            return false;
        }
        private string VerificarImpedimentosDelecao(UsuarioModel usuario)
        {
            if (usuario.Consultas != null && usuario.Consultas.Count > 0)
            {
                return "Não é possível excluir o usuario, pois ele tem consultas vinculadas.";
            }

            
            return null;
        }
        private void DesativarRecursosRelacionados(UsuarioModel usuario)
        {
            if(usuario.Consultas != null)
                foreach(var consulta in usuario.Consultas)
                {
                    consulta.StatusSistema = false;
                }
        }

    }
}


