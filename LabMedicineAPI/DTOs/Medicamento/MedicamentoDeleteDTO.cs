using System.ComponentModel.DataAnnotations;

namespace LabMedicineAPI.DTOs.Medicamento
{
    public class MedicamentoDeleteDTO
    {
        [Required]
        public int Id { get; set; }

    }
}
