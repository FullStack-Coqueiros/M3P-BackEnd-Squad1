using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabMedicineAPI.DTOs
{
    public class ExameDeleteDTO
    {
        [Required(ErrorMessage = "O campo ID é obrigatório")]
        public int Id { get; set; }
    }
}