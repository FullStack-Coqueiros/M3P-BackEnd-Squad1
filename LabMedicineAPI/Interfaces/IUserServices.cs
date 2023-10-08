using LabMedicineAPI.Model;

namespace LabMedicineAPI.Interfaces
{
    public interface IUserServices
    {
        UsuarioModel Atualizar(UsuarioModel usuario);
        UsuarioModel Criar(UsuarioModel usuario);
        void Deletar(string login);
        List<UsuarioModel> Obter();
        UsuarioModel ObterPorLogin(string login);
    }
}