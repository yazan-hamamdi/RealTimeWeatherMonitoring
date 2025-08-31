using RealTimeWeatherMonitoring.Interfaces;
using RealTimeWeatherMonitoring.Models;

namespace RealTimeWeatherMonitoring.Observers.Subscribers
{
    public class RainBot : ISubscriber
    {
        private readonly RainBotConfig _rainBotConfig;

        public RainBot(RainBotConfig rainBotConfig)
        {
            _rainBotConfig = rainBotConfig;
        }

        public void Update(WeatherData weatherData)
        {
            if (weatherData.Humidity > _rainBotConfig.HumidityThreshold)
            {
                Activate();
            }
        }

        private void Activate()
        {
            if (_rainBotConfig.Enabled)
            {
                Console.WriteLine($"activated!");
                Console.WriteLine(_rainBotConfig.Message);
            }
        }

    }
}
