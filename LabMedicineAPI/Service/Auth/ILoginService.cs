using LabMedicineAPI.DTOs.Login;

namespace LabMedicineAPI.Service.Auth
{
    public interface ILoginService
    {
        string GeraNovaSenha(ResetSenhaDTO resetSenha);
        string GeraTokenJWT(LoginDTO login);
        bool Login(LoginDTO login);
    }
}