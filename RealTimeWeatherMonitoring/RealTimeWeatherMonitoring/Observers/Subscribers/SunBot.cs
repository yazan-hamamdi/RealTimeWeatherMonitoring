using RealTimeWeatherMonitoring.Interfaces;
using RealTimeWeatherMonitoring.Models;

namespace RealTimeWeatherMonitoring.Observers.Subscribers
{
    public class SunBot : ISubscriber
    {
        private readonly SunBotConfig _sunBotConfig;

        public SunBot(SunBotConfig sunBotConfig)
        {
            _sunBotConfig = sunBotConfig;
        }

        public void Update(WeatherData weatherData)
        {
            if (weatherData.Temperature > _sunBotConfig.TemperatureThreshold)
            {
                Activate();
            }
        }

        private void Activate()
        {
            if (_sunBotConfig.Enabled)
            {
                Console.WriteLine($"activated!");
                Console.WriteLine(_sunBotConfig.Message);
            }
        }

    }
}
