using RealTimeWeatherMonitoring.Enums;
using RealTimeWeatherMonitoring.Interfaces.RealTimeWeatherMonitoring.Interfaces;
using RealTimeWeatherMonitoring.Models;
using System.Text.Json;

namespace RealTimeWeatherMonitoring.Parsers
{
    public class JsonWeatherDataParser : IWeatherDataParser
    {
        public bool TryParse(string input, out WeatherData data)
        {
            try
            {
                data = JsonSerializer.Deserialize<WeatherData>(input) ?? new WeatherData();
                return true;
            }
            catch
            {
                data = null!;
                return false;
            }
        }
    }
}
