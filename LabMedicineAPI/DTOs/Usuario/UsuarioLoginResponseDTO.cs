namespace LabMedicineAPI.DTOs.Usuario
{
    public class UsuarioLoginResponseDTO
    {
        
        public string NomeCompleto { get; set; }
        public string Tipo { get; set; }
        public bool StatusSistema { get; set; } = true;
        public string Token { get; set; }
    }
}
