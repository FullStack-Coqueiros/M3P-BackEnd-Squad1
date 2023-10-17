using System.Text.Json.Serialization;

namespace LabMedicineAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoDietaEnum
    {
        LowCard,
        Dash,
        Paleolitica,
        Cetogenica,
        Dukan,
        Mediterranea,
        Outra
    }
}