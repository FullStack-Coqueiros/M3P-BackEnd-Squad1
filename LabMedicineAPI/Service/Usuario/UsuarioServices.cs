using AutoMapper;
using LabMedicineAPI.DTOs.Paciente;
using LabMedicineAPI.DTOs.Usuario;
using LabMedicineAPI.Model;
using LabMedicineAPI.Repositories;
using LabMedicineAPI.Service.Paciente;

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

        public UsuarioModel UsuarioCreateDTO(UsuarioCreateDTO usuarioCreateDTO)
        {
            var usuario = _mapper.Map<UsuarioModel>(usuarioCreateDTO);
            var usuarioCreated = _repository.Create(usuario);
            var usuarioCreatedDTO = _mapper.Map<UsuarioModel>(usuarioCreated);
            return usuarioCreatedDTO;

        }
        public UsuarioGetDTO UsuarioUpdateDTO(int id ,UsuarioUpdateDTO updateUsuarioDTO)
        {
            UsuarioModel model = _repository.GetById(id);
            model = _mapper.Map(updateUsuarioDTO, model);
            _repository.Update(model);
            UsuarioModel usuarioUpdated = _repository.GetById(id);
            UsuarioGetDTO usuarioGet = _mapper.Map<UsuarioGetDTO>(usuarioUpdated);
            return usuarioGet;
            //var usuarioGetId = _repository.GetById(id);
            //if (usuarioGetId == null)
            //{
            //    throw new Exception("Paciente não encontrado");
            //}
            //UsuarioModel model = _mapper.Map<UsuarioModel>(updateUsuarioDTO);
            //_repository.Update(model);
            //UsuarioGetDTO usuarioGet = _mapper.Map<UsuarioGetDTO>(updateUsuarioDTO);
            //return usuarioGet;
            //_mapper.Map(updateUsuarioDTO, usuario);

            //var usuarioUpdated = _repository.Update(usuario);
            //var usuarioUpdateDTO = _mapper.Map<UsuarioModel>(usuarioUpdated);
            //return usuarioUpdateDTO;
        }

        public bool DeleteUsuario(int id)
        {
            return _repository.Delete(id);
        }

    }

}
