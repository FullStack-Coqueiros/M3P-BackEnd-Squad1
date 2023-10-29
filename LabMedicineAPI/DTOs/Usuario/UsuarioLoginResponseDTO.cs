namespace LabMedicineAPI.DTOs.Usuario
{
    public class UsuarioLoginResponseDTO
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Tipo { get; set; }
        public bool StatusSistema { get; set; } = true;
    }
}
