using RealTimeWeatherMonitoring.Interfaces;
using RealTimeWeatherMonitoring.Models;

namespace RealTimeWeatherMonitoring.Observers.Subscribers
{
    public abstract class BaseBot<TConfig> : ISubscriber where TConfig : BotConfig
    {
        protected readonly TConfig _config;
        public string Name => GetType().Name;
        public bool Enabled => _config.Enabled;
        protected string Message => _config.Message;

        protected BaseBot(TConfig config)
        {
            _config = config;
        }

        public abstract void Update(WeatherData weatherData);

        protected void Activate()
        {
            Console.WriteLine($"{Name} activated!");
            Console.WriteLine(Message);
        }
    }
}
