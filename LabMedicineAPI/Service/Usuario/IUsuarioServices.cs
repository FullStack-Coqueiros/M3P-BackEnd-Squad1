using LabMedicineAPI.DTOs.Usuario;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.Service.Usuario
{
    public interface IUsuarioServices
    {
        bool DeleteUsuario(int id);
        List<UsuarioGetDTO> Get();
        UsuarioGetDTO GetById(int id);
        UsuarioModel UsuarioCreateDTO(UsuarioCreateDTO usuarioCreateDTO);
        UsuarioModel UsuarioUpdateDTO(int id, UsuarioUpdateDTO updateUsuarioDTO);
    }
}