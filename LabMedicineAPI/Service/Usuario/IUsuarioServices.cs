using LabMedicineAPI.DTOs.Usuario;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.Service.Usuario
{
    public interface IUsuarioServices
    {
        bool DeleteUsuario(int id);
        IEnumerable<UsuarioGetDTO> Get();
        UsuarioGetDTO GetById(int id);
        UsuarioGetDTO UsuarioCreateDTO(UsuarioCreateDTO usuarioCreateDTO);
        UsuarioGetDTO UsuarioUpdateDTO(int id, UsuarioUpdateDTO updateUsuarioDTO);
    }
}