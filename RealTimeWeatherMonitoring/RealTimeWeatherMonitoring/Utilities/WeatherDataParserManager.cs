using RealTimeWeatherMonitoring.Interfaces.RealTimeWeatherMonitoring.Interfaces;
using RealTimeWeatherMonitoring.Models;
using RealTimeWeatherMonitoring.Parsers;

namespace RealTimeWeatherMonitoring.Utilities
{
    public class WeatherDataParserManager
    {
        private readonly List<IWeatherDataParser> _parsers;

        public WeatherDataParserManager()
        {
            _parsers = new List<IWeatherDataParser>
             {
               new JsonWeatherDataParser(),
               new XmlWeatherDataParser()
             };
        }

        public WeatherData Process(string input)
        {
            foreach (var parser in _parsers)
            {
                if (parser.TryParse(input, out var data))
                    return data;
            }

            throw new NotSupportedException("Unknown weather data format");
        }
    }
}
