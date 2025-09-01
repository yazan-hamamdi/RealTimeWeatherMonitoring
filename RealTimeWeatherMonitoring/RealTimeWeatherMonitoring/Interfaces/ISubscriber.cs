using RealTimeWeatherMonitoring.Models;

namespace RealTimeWeatherMonitoring.Interfaces
{
    public interface ISubscriber
    {
        void Update(WeatherData weatherData);
    }
}