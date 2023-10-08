using LabMedicineAPI.Interfaces;
using static LabMedicineAPI.Services.Auth.UserServices;

namespace LabMedicineAPI.Services.Auth
{


    public class UserServices : IUserServices
    {
        public Usuario Atualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario Criar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(string login)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Obter()
        {
            throw new NotImplementedException();
        }

        public Usuario ObterPorLogin(string login)
        {//implantar busca de usuario no db
            return new Usuario()
            {
                Nome = "Vitor",
                Login = "vitor.lassen",
                Senha = "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=",
                Permissao = "Professor",
                Interno = true
            };
        }
    }

}
