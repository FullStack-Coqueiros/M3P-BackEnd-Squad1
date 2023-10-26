using System.Text.Json.Serialization;

namespace LabMedicineAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EstadoCivilEnum
    {
        Solteiro,
        Casado,
        Divorciado,
        Viuvo,
        Outro
    }
}