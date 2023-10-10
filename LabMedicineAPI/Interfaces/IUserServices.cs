using LabMedicineAPI.DTOs.Login;
using LabMedicineAPI.DTOs.Usuario;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.Interfaces
{
    public interface IUserServices
    {
        UsuarioModel Atualizar(int id, UsuarioUpdateDTO UpdateDTO);
        UsuarioModel Criar(UsuarioCreateDTO createDTO);
        bool Deletar(int id);
        IEnumerable<UsuarioGetDTO> Obter();
        UsuarioModel ObterPorLogin(LoginDTO login);
    }
}