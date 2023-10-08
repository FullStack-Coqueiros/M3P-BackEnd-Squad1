namespace LabMedicineAPI.Interfaces
{
    public interface IUserServices
    {
        Usuario Atualizar(Usuario usuario);
        Usuario Criar(Usuario usuario);
        void Deletar(string login);
        List<Usuario> Obter();
        Usuario ObterPorLogin(string login);
    }
}