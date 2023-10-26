using System.Text.Json.Serialization;

namespace LabMedicineAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoEnum
    {
        Medico,
        Administrador,
        Enfermeiro
    }
}