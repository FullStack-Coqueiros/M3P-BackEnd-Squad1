using System.Text.Json.Serialization;

namespace LabMedicineAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GeneroEnum
    {
        Masculino,
        Feminino,
        Outro
    }
}