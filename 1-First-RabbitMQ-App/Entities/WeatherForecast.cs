using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Entities
{
    public class WeatherForecast
    {
        public int Id { get; set; } = -1;
        public long CreatedAt { get; set; } = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeMilliseconds();

        public long ETA { get; set; } = new DateTimeOffset(DateTime.UtcNow.AddMinutes(5)).ToUnixTimeMilliseconds();

        public int TCelsius { get; set; } = 0;

        public int TFahrenheit { get; set; } = 32;

        public string? Summary { get; set; } = "Cloudy and Static";
 

        public string ToSerialized() 
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
