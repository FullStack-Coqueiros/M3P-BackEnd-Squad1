using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LabMedicineAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UnidadeEnum
    {
        mg,
        mcg,
        g,
        mL,
        Porcentagem

    }
}