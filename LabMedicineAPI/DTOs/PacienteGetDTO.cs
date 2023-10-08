using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LabMedicineAPI.Enums;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.DTOs
{
    public class PacienteGetDTO
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public GeneroEnum Genero { get; set; }
        public DateTime DataNascimento { get; set; }

        public PacienteGetDTO(int id, string nomeCompleto, GeneroEnum genero, DateTime dataNascimento)
        {
            Id = id;
            NomeCompleto = nomeCompleto;
            Genero = genero;
            DataNascimento = dataNascimento;
        }
    }
}