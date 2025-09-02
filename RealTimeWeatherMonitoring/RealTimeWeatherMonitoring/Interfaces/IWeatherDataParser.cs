using RealTimeWeatherMonitoring.Models;

namespace RealTimeWeatherMonitoring.Interfaces
{
    namespace RealTimeWeatherMonitoring.Interfaces
    {
        public interface IWeatherDataParser
        {
            public WeatherData Parse(string input);
        }
    }
}