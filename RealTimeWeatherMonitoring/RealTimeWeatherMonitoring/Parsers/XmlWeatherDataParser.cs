using RealTimeWeatherMonitoring.Enums;
using RealTimeWeatherMonitoring.Interfaces.RealTimeWeatherMonitoring.Interfaces;
using RealTimeWeatherMonitoring.Models;
using System.Xml.Serialization;

namespace RealTimeWeatherMonitoring.Parsers
{
    public class XmlWeatherDataParser : IWeatherDataParser
    {
        public bool TryParse(string input, out WeatherData data)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(WeatherData));
                using var reader = new StringReader(input);
                data = (WeatherData)(serializer.Deserialize(reader) ?? new WeatherData());
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
