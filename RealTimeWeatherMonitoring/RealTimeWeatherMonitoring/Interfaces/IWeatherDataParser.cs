using RealTimeWeatherMonitoring.Models;

namespace RealTimeWeatherMonitoring.Interfaces
{
    namespace RealTimeWeatherMonitoring.Interfaces
    {
        public interface IWeatherDataParser
        {
            bool TryParse(string input, out WeatherData data);
        }
    }
}