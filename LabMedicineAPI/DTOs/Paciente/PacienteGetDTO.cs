using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LabMedicineAPI.Enums;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.DTOs.Paciente
{
    public class PacienteGetDTO
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public GeneroEnum Genero { get; set; }
        public DateTime DataNascimento { get; set; }

    }
}