using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabMedicineAPI.DTOs.Consulta
{
    public class ConsultaDeleteDTO
    {
        [Required(ErrorMessage = "O campo ID é obrigatório")]
        public int Id { get; set; }
    }
}