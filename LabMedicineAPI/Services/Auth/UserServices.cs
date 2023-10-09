using LabMedicineAPI.Interfaces;
using LabMedicineAPI.Model;
using static LabMedicineAPI.Services.Auth.UserServices;

namespace LabMedicineAPI.Services.Auth
{


    public class UserServices : IUserServices
    {
        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }

        public UsuarioModel Criar(UsuarioModel usuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(string login)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioModel> Obter()
        {
            throw new NotImplementedException();
        }

        public UsuarioModel ObterPorLogin(string login)
        {//implantar busca de usuario no db
            return new UsuarioModel()
            {
                NomeCompleto = "Teste Nome",
                Email = "teste@teste",
                Senha = "pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=",
                Tipo = Enums.TipoEnum.Medico,
                StatusSistema = true
            };
        }
    }

}
