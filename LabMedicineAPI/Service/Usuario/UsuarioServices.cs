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
            var usuario = _repository.GetById(id);
            var usuarioDTO = _mapper.Map<UsuarioGetDTO>(usuario);
            return usuarioDTO;
        }

        public UsuarioModel UsuarioCreateDTO(UsuarioCreateDTO usuarioCreateDTO)
        {
            var usuario = _mapper.Map<UsuarioModel>(usuarioCreateDTO);
            var usuarioCreated = _repository.Create(usuario);
            var usuarioCreatedDTO = _mapper.Map<UsuarioModel>(usuarioCreated);
            return usuarioCreatedDTO;

        }
        public UsuarioModel UsuarioUpdateDTO(int id, UsuarioUpdateDTO updateUsuarioDTO)
        {
            var usuario = _repository.GetById(id);
            if (usuario == null)
            {
                throw new Exception("Paciente não encontrado");
            }
            _mapper.Map(updateUsuarioDTO, usuario);

            var usuarioUpdated = _repository.Update(usuario);
            var usuarioUpdateDTO = _mapper.Map<UsuarioModel>(usuarioUpdated);
            return usuarioUpdateDTO;
        }

        public bool DeleteUsuario(int id)
        {
            return _repository.Delete(id);
        }

    }

}
