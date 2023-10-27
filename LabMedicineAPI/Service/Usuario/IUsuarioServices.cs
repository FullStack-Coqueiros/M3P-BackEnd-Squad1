using LabMedicineAPI.DTOs.Usuario;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.Service.Usuario
{
    public interface IUsuarioServices
    {
        UsuarioGetDTO GetByEmail(string email);
        IEnumerable<UsuarioGetDTO> Get();
        UsuarioGetDTO GetById(int id);
        UsuarioGetDTO CreateUsuario(UsuarioCreateDTO usuario);
        UsuarioGetDTO UsuarioUpdateDTO(int id, UsuarioUpdateDTO updateUsuarioDTO);
        bool DeleteUsuario(int id, int userId);
    }
}