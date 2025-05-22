using System.Text.Json;
using System.Text.Json.Serialization;

namespace GamingClub.Application.Converters
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        // Формат: "2025-05-20 14:30" (без секунд и миллисекунд)
        private const string Format = "yyyy-MM-dd HH:mm";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Парсим строку обратно в DateTime при десериализации
            return DateTime.ParseExact(reader.GetString()!, Format, null);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            // Форматируем DateTime в строку при сериализации
            writer.WriteStringValue(value.ToString(Format));
        }
    }
}