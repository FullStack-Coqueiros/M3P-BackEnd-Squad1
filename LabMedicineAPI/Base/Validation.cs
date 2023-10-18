using System.Text.Json.Serialization;
using System.Text.Json;
using LabMedicineAPI.Enums;

namespace LabMedicineAPI.Base
{


    public partial class Validation
    {
        public sealed class EstadoCivilConverter : JsonConverter<EstadoCivilEnum>
        {
            public override EstadoCivilEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var value = reader.GetString();
                if (!Enum.TryParse<EstadoCivilEnum>(value, out var result))
                    throw new JsonException($"Por favor, informe um valor válido para a Estado Civil : {string.Join(",", Enum.GetNames(typeof(EstadoCivilEnum)))}");

                return result;
            }

            public override void Write(Utf8JsonWriter writer, EstadoCivilEnum value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
        }
        public sealed class GeneroConverter : JsonConverter<GeneroEnum>
        {
            public override GeneroEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var value = reader.GetString();
                if (!Enum.TryParse<GeneroEnum>(value, out var result))
                    throw new JsonException($"Por favor, informe um valor válido para a Genero : {string.Join(",", Enum.GetNames(typeof(GeneroEnum)))}");

                return result;
            }

            public override void Write(Utf8JsonWriter writer, GeneroEnum value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
        }
        public sealed class TipoDietaConverter : JsonConverter<TipoDietaEnum>
        {
            public override TipoDietaEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var value = reader.GetString();
                if (!Enum.TryParse<TipoDietaEnum>(value, out var result))
                    throw new JsonException($"Por favor, informe um valor válido para a Tipo de dieta : {string.Join(",", Enum.GetNames(typeof(TipoDietaEnum)))}");

                return result;
            }

            public override void Write(Utf8JsonWriter writer, TipoDietaEnum value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
        }
        public sealed class TipóConverter : JsonConverter<TipoEnum>
        {
            public override TipoEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var value = reader.GetString();
                if (!Enum.TryParse<TipoEnum>(value, out var result))
                    throw new JsonException($"Por favor, informe um valor válido para a Tipo : {string.Join(",", Enum.GetNames(typeof(TipoEnum)))}");

                return result;
            }

            public override void Write(Utf8JsonWriter writer, TipoEnum value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
        }
        public sealed class TipoExercicioConverter : JsonConverter<TipoExercicioEnum>
        {
            public override TipoExercicioEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var value = reader.GetString();
                if (!Enum.TryParse<TipoExercicioEnum>(value, out var result))
                    throw new JsonException($"Por favor, informe um valor válido para a Tipo de Exercicio : {string.Join(",", Enum.GetNames(typeof(TipoEnum)))}");

                return result;
            }

            public override void Write(Utf8JsonWriter writer, TipoExercicioEnum value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
        }
        public sealed class TipoMedicamentoConverter : JsonConverter<TipoMedicamentoEnum>
        {
            public override TipoMedicamentoEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var value = reader.GetString();
                if (!Enum.TryParse<TipoMedicamentoEnum>(value, out var result))
                    throw new JsonException($"Por favor, informe um valor válido para a Tipo de Medicamento : {string.Join(",", Enum.GetNames(typeof(TipoMedicamentoEnum)))}");

                return result;
            }

            public override void Write(Utf8JsonWriter writer, TipoMedicamentoEnum value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
        }
        public sealed class UnidadeConverter : JsonConverter<UnidadeEnum>
        {
            public override UnidadeEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var value = reader.GetString();
                if (!Enum.TryParse<UnidadeEnum>(value, out var result))
                    throw new JsonException($"Por favor, informe um valor válido para a Unidade : {string.Join(",", Enum.GetNames(typeof(UnidadeEnum)))}");

                return result;
            }

            public override void Write(Utf8JsonWriter writer, UnidadeEnum value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
        }

    }

}
