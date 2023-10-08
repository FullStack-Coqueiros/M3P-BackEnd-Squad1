using LabMedicineAPI.DTOs;

namespace LabMedicineAPI.Interfaces
{
    public interface IAuthServices
    {
        bool Autenticar(LoginDTO login);
        string GerarToken(LoginDTO loginDTO);
    }
}
