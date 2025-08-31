using RealTimeWeatherMonitoring.Interfaces;
using RealTimeWeatherMonitoring.Models;

namespace RealTimeWeatherMonitoring.Observers.Subscribers
{
    public class SnowBot : ISubscriber
    {
        private readonly SnowBotConfig _snowBotConfig;

        public SnowBot(SnowBotConfig snowBotConfig)
        {
            _snowBotConfig = snowBotConfig;
        }

        public void Update(WeatherData weatherData)
        {
            if (weatherData.Temperature < _snowBotConfig.TemperatureThreshold)
            {
                Activate();
            }
        }

        private void Activate()
        {
            if (_snowBotConfig.Enabled)
            {
                Console.WriteLine($"activated!");
                Console.WriteLine(_snowBotConfig.Message);
            }
        }

    }
}
