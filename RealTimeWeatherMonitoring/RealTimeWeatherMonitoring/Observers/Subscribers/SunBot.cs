using RealTimeWeatherMonitoring.Interfaces;
using RealTimeWeatherMonitoring.Models;

namespace RealTimeWeatherMonitoring.Observers.Subscribers
{
    public class SunBot : ISubscriber
    {
        private readonly SunBotConfig _sunBotConfig;
        public string Name => GetType().Name;
        public bool Enabled => _sunBotConfig.Enabled;

        public SunBot(SunBotConfig sunBotConfig)
        {
            _sunBotConfig = sunBotConfig;
        }

        public void Update(WeatherData weatherData)
        {
            if (Enabled && weatherData.Temperature >= _sunBotConfig.TemperatureThreshold)
            {
                Activate();
            }
        }

        private void Activate()
        {
            Console.WriteLine($"{Name} activated!");
            Console.WriteLine(_sunBotConfig.Message);
        }
    }
}
