using RealTimeWeatherMonitoring.Interfaces;
using RealTimeWeatherMonitoring.Models;

namespace RealTimeWeatherMonitoring.Observers.Subscribers
{
    public class RainBot : ISubscriber
    {
        private readonly RainBotConfig _rainBotConfig;
        public string Name => GetType().Name;
        public bool Enabled => _rainBotConfig.Enabled;

        public RainBot(RainBotConfig rainBotConfig)
        {
            _rainBotConfig = rainBotConfig;
        }

        public void Update(WeatherData weatherData)
        {
            if (Enabled && weatherData.Humidity >= _rainBotConfig.HumidityThreshold)
            {
                Activate();
            }
        }

        private void Activate()
        {
            Console.WriteLine($"{Name} activated!");
            Console.WriteLine(_rainBotConfig.Message);
        }

    }
}
