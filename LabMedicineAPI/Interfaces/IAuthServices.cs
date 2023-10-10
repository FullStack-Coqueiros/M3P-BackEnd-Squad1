using LabMedicineAPI.DTOs.Login;

namespace LabMedicineAPI.Interfaces
{
    public interface IAuthServices
    {
        bool Autenticar(LoginDTO login);
        string GerarToken(LoginDTO loginDTO);
    }
}
