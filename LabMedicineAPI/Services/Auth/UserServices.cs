using static LabMedicineAPI.Services.Auth.UserServices;

namespace LabMedicineAPI.Services.Auth
{
    public class UserServices
    {
        public class UserServices : IUserServices, IUserServices
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
            {
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
}
