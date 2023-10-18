using System.Text.Json.Serialization;

namespace LabMedicineAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoExercicioEnum
    {
        ResistenciaAerobica,
        ResistenciaMuscular,
        Flexibilidade,
        Forca,
        Agilidade,
        Outro
    }
}