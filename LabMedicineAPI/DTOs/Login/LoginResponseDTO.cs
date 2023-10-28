using LabMedicineAPI.DTOs.Usuario;

namespace LabMedicineAPI.DTOs.Login
{
    public class LoginResponseDTO
    {
        public virtual UsuarioLoginResponseDTO UsuarioGet { get; set; }
        public String Token { get; set; }

    }
}
