using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using LabMedicineAPI.Model;

namespace LabMedicineAPI.DTOs.Exame
{
    public class ExameGetDTO
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public DateTime Horario { get; set; } 
        public bool StatusSistema { get; set; } = true;
        public int PacienteId { get; set; }
        public int UsuarioId { get; set; }
        public string NomeExame { get; set; }
        public string TipoExame { get; set; }
        public string Laboratorio { get; set; }
        public string Url { get; set; }
        public string Resultados { get; set; }
    }
}