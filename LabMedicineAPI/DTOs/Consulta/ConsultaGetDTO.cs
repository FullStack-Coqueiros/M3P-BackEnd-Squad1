using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabMedicineAPI.DTOs.Consulta
{
    public class ConsultaGetDTO
    {
        public int Id { get; set; }
        public string MotivoConsulta { get; set; }
        public DateTime Data { get; set; }
        public DateTime Horario { get; set; }
        public required string ProblemaDescricao { get; set; }
        public string? MedicacaoIndicada { get; set; }
        public string DosagemEPrecaucoes { get; set; }
        public int PacienteId { get; set; }
        public int UsuarioId { get; set; }

    }
}