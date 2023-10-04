namespace LabMedicineAPI.Model
{
    public class Consulta
    {
        public string MotivoConsulta { get; set; }
        public DateTime DataConsulta { get; set; }
        public DateTime HorarioConsulta { get; set; }
        public string ProblemaDescricao { get; set; }
        public string MedicacaoIndicada { get; set; }
        public string DosagemEPrecaucoes { get; set; }
        public bool StatusDoSistema { get; set; }
        public int PacienteId { get; set; }
        public int UsuarioId { get; set; }
    }
}
