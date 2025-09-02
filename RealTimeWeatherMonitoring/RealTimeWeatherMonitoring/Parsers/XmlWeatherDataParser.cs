using RealTimeWeatherMonitoring.Interfaces.RealTimeWeatherMonitoring.Interfaces;
using RealTimeWeatherMonitoring.Models;
using System.Xml.Serialization;

namespace RealTimeWeatherMonitoring.Parsers
{
    public class XmlWeatherDataParser : IWeatherDataParser
    {
        public WeatherData Parse(string input)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(WeatherData));
                using var reader = new StringReader(input);
                return (WeatherData)(serializer.Deserialize(reader)
                       ?? throw new InvalidOperationException("Failed to parse XML into WeatherData."));
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException($"Invalid XML format: {ex.Message}", ex);
            }
        }
    }
}
