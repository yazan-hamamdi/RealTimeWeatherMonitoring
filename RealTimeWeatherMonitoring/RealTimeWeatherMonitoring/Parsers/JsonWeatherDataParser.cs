using RealTimeWeatherMonitoring.Interfaces.RealTimeWeatherMonitoring.Interfaces;
using RealTimeWeatherMonitoring.Models;
using System.Text.Json;

namespace RealTimeWeatherMonitoring.Parsers
{
    public class JsonWeatherDataParser : IWeatherDataParser
    {
        public WeatherData Parse(string input)
        {
            try
            {
                return JsonSerializer.Deserialize<WeatherData>(input)
                       ?? throw new InvalidOperationException("Failed to parse JSON into WeatherData.");
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException($"Invalid JSON format: {ex.Message}", ex);
            }
        }
    }
}
