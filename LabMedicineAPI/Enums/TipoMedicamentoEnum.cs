using System.Text.Json.Serialization;

namespace LabMedicineAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoMedicamentoEnum
    {
        Capsula,
        Comprimido,
        Liquido,
        Creme,
        Gel,
        Inalacao,
        Injecao,
        Spray
    }
}