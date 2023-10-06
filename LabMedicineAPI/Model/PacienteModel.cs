using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabMedicineAPI.Enums;

namespace LabMedicineAPI.Model
{
    public class PacienteModel
    {
        public DateTime DataNasc { get; set; }
        public string RG { get; set; }
        public EstadoCivilEnum EstadoCivil { get; set; }
        public string Naturalidade { get; set; }
        public string ContatoEmergencia { get; set; }
        public string ListaAlergias { get; set; }
        public string ListaCuidadosEspecificos { get; set; }
        public string Convenio { get; set; }
        public string NumeroConvenio { get; set; }
        public DateTime? ValidadeConvenio { get; set; }
        public Endereco Endereco { get; set; }
    }
}