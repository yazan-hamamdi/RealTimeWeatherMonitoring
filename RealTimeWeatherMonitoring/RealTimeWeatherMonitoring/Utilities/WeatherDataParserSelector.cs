using RealTimeWeatherMonitoring.Interfaces.RealTimeWeatherMonitoring.Interfaces;
using RealTimeWeatherMonitoring.Parsers;

namespace RealTimeWeatherMonitoring.Utilities
{
    public class WeatherDataParserSelector
    {
        public IWeatherDataParser SelectParser(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Input cannot be null or empty", nameof(input));

            string trimmed = input.TrimStart();

            if (trimmed.StartsWith("{"))
                return new JsonWeatherDataParser();

            if (trimmed.StartsWith("<"))
                return new XmlWeatherDataParser();

            throw new NotSupportedException("Unsupported weather data format");
        }
    }
}
