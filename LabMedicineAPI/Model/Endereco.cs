using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabMedicineAPI.Model
{
    public class Endereco
    {
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string PontoReferencia { get; set; }


    }
}