using RealTimeWeatherMonitoring.Interfaces.RealTimeWeatherMonitoring.Interfaces;
using RealTimeWeatherMonitoring.Models;
using RealTimeWeatherMonitoring.Parsers;

namespace RealTimeWeatherMonitoring.Utilities
{
    public class WeatherDataParser
    {
        private IWeatherDataParser _parser;

        public void SetParser(IWeatherDataParser parser)
        {
            _parser = parser;
        }

        public WeatherData Parse(string input)
        {
            if (_parser == null)
                throw new InvalidOperationException("Parser has not been set.");

            return _parser.Parse(input);
        }
    }
}
