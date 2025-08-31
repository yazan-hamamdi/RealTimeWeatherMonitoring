using RealTimeWeatherMonitoring.Interfaces;
using RealTimeWeatherMonitoring.Models;

namespace RealTimeWeatherMonitoring.Observers.Subscribers
{
    public class SnowBot : ISubscriber
    {
        private readonly SnowBotConfig _snowBotConfig;
        public string Name => GetType().Name;
        public bool Enabled => _snowBotConfig.Enabled;

        public SnowBot(SnowBotConfig snowBotConfig)
        {
            _snowBotConfig = snowBotConfig;
        }

        public void Update(WeatherData weatherData)
        {
            if (Enabled && weatherData.Temperature <= _snowBotConfig.TemperatureThreshold)
            {
                Activate();
            }
        }

        private void Activate()
        {
            Console.WriteLine($"{Name} activated!");
            Console.WriteLine(_snowBotConfig.Message);
        }

    }
}
