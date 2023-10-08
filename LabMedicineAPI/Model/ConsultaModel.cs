using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LabMedicineAPI.Base;

namespace LabMedicineAPI.Model
{
    public class ConsultaModel:BaseAtendimento
    {
        [Column(TypeName = "VARCHAR"), Required, MaxLength(64), MinLength(8)]
        public string MotivoConsulta { get; set; }
       
        [Column(TypeName = "VARCHAR"), Required, MaxLength(1024), MinLength(16)]
        public string ProblemaDescricao { get; set; }
        public string? MedicacaoIndicada { get; set; }
        [Column(TypeName = "VARCHAR"), Required, MaxLength(256), MinLength(16)]
        public string DosagemEPrecaucoes { get; set; }
      
        
    }
}
